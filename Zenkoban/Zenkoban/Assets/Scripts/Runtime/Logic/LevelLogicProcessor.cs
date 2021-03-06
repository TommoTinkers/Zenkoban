using System;
using System.Collections.Generic;
using System.Linq;
using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Common;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Extensions;
using Zenkoban.Runtime.Extensions.Level;

namespace Zenkoban.Runtime.Logic
{
	public class LevelLogicProcessor : IMoveCommandProvider
	{
		private bool isMoving = false;

		public event Action<IEnumerable<MoveNotification>, Action> OnMove;
		public event Action OnLevelComplete;

		private readonly Level level;
		private readonly MoveValidator moveValidator;

		private readonly Stack<Action> undoStack = new Stack<Action>();

		public LevelLogicProcessor(Level level)
		{
			this.level = level;
			moveValidator = new MoveValidator(level);
		}

		public void AttemptMove(MoveDirection direction)
		{
			if (isMoving) return;
			if (!moveValidator.Validate(level.FindPlayer(), direction)) return;
			
			Move(direction);
		}
		
		private void Move(MoveDirection direction)
		{
			var sequencer = new MoveSequencer(level);

			var playerPos = level.FindPlayer();
			var playerDest = playerPos + direction;

			var moveType = DetermineMoveType(playerDest);

			switch (moveType)
			{
				case MoveType.Normal:
					playerDest = level.GetSlidePoint(playerDest, direction);
					break;
				case MoveType.BlockPush:
					HandleBlockPush(direction, playerDest, sequencer);
					break;
				case MoveType.MirrorBlockPush:
					HandleMirrorBlockPush(direction, playerDest, sequencer);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			
			sequencer.SequenceMove(playerPos, playerDest);
			
			
			(var forward, var undo) = sequencer.CreateDispatchPair(NotifiyOnMove);

			undoStack.Push(undo);
			isMoving = true;
			forward();
		}

		private void HandleMirrorBlockPush(MoveDirection direction, LevelPoint playerDest, MoveSequencer sequencer)
		{
			sequencer.SequenceMove(playerDest, level.GetSlidePoint(playerDest + direction, direction));

			var otherMirrorBlockLocations
				= level.AllOtherMirrorBlocks(level[playerDest])
					.Select(m => level.FindBlock(m));

			var mirrorDirection = direction.Invert();

			foreach (var mirrorBlock in otherMirrorBlockLocations)
			{
				var destPoint = mirrorBlock + mirrorDirection;
				if (level.IsNone(destPoint))
				{
					destPoint = level.GetSlidePoint(mirrorBlock + mirrorDirection, mirrorDirection);
					sequencer.SequenceMove(mirrorBlock, destPoint, mirrorDirection);
				}
			}
		}

		private void HandleBlockPush(MoveDirection direction, LevelPoint playerDest, MoveSequencer sequencer)
		{
			var slide = level.GetSlidePoint(playerDest + direction, direction);
			sequencer.SequenceMove(playerDest, slide);
		}

		public void Undo()
		{
			if (!undoStack.Any() || isMoving) return;

			isMoving = true;
			undoStack.Pop()();
		}

		private void HandleMoveComplete()
		{
			if (level.CountOpenGoalSquares() > 0)
			{
				isMoving = false;
			}
			else
			{
				OnLevelComplete?.Invoke();
			}
		}

		private void NotifiyOnMove(IEnumerable<MoveNotification> notifications)
		{
			OnMove?.Invoke(notifications, HandleMoveComplete);
		}

		private MoveType DetermineMoveType(LevelPoint intendedPlayerDestination)
		{
			switch(level[intendedPlayerDestination].Type)
			{
				case BlockType.None:
					return MoveType.Normal;
				case BlockType.Block:
					return MoveType.BlockPush;
				case BlockType.MirrorBlock:
					return MoveType.MirrorBlockPush;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}