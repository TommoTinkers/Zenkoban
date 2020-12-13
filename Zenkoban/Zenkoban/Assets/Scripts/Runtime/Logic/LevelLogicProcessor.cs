using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;
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

		public void Move(MoveDirection direction)
		{
			if (isMoving) return;
			if (!moveValidator.Validate(level.FindPlayer(), direction)) return;
			
			var sequencer = new MoveSequencer(level);
			
			var playerPos = level.FindPlayer();
			var playerDest = playerPos + direction;
			
			HandleBlockPush(direction, playerDest, sequencer);

			HandleMirrorBlockPush(direction, playerDest, sequencer);
			
			sequencer.SequenceMove(playerPos, playerDest, direction);

			(var forward, var undo) = sequencer.CreateDispatchPair(NotifiyOnMove);
			
			undoStack.Push(undo);
			isMoving = true;
			forward();
		}

		private void HandleMirrorBlockPush(MoveDirection direction, LevelPoint playerDest, MoveSequencer sequencer)
		{
			if (level[playerDest].Type != BlockType.MirrorBlock) return;
			sequencer.SequenceMove(playerDest, playerDest + direction, direction);
			var allOtherMirrorBlocks = level.AllOtherMirrorBlocks(level[playerDest])
				.Select(m => level.FindBlock(m));
			foreach (var mirrorBlock in allOtherMirrorBlocks)
			{
				var mirrorDirection = direction.Invert();

				var destPoint = mirrorBlock + mirrorDirection;
				if (level.IsNone(destPoint))
				{
					sequencer.SequenceMove(mirrorBlock, mirrorBlock + mirrorDirection, mirrorDirection);
				}
			}
		}

		private void HandleBlockPush(MoveDirection direction, LevelPoint playerDest, MoveSequencer sequencer)
		{
			if (level[playerDest].Type == BlockType.Block)
			{
				sequencer.SequenceMove(playerDest, playerDest + direction, direction);
			}
		}

		public void Undo()
		{
			if (!undoStack.Any() || isMoving) return;
			
			isMoving = true;
			undoStack.Pop()();
		}
		
		private void HandleMoveComplete()
		{
			if (level.OpenGoalSquares() > 0)
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
	}
}