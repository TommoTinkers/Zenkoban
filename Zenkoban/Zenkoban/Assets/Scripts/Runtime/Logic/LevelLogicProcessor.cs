using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenkoban.Runtime.Common;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Extensions.Level;

namespace Zenkoban.Runtime.Logic
{
	public class LevelLogicProcessor : IMoveCommandProvider
	{
		private bool isMoving = false;
		
		public event Action<IEnumerable<MoveNotification>, Action> OnMove;
		
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
			
			
			if (level[playerDest].Type == BlockType.Block)
			{
				sequencer.SequenceMove(playerDest, playerDest + direction, direction);
			}
			
			sequencer.SequenceMove(playerPos, playerDest, direction);

			(var forward, var undo) = sequencer.CreateDispatchPair(NotifiyOnMove);
			
			undoStack.Push(undo);
			isMoving = true;
			forward();
		}

		public void Undo()
		{
			if (undoStack.Any() && !isMoving)
			{
				isMoving = true;
				undoStack.Pop()();
			}
		}
		
		private void HandleMoveComplete()
		{
			isMoving = false;
		}
		
		private void NotifiyOnMove(IEnumerable<MoveNotification> notifications)
		{
			OnMove?.Invoke(notifications, HandleMoveComplete);
		}
	}
}