using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
			if (!moveValidator.Validate(level.FindPlayer(), direction)) return;

			var moveFunctions = new List<(Func<MoveNotification>, Func<MoveNotification>)>();
			
			var playerPos = level.FindPlayer();
			var playerDest = playerPos + direction;
			
			var playerMove = GenerateMovePair(playerPos, playerDest, direction);
			var blockMove = GenerateMovePair(playerDest, playerDest + direction, direction);

			if (level[playerDest].Type == BlockType.Block)
			{
				moveFunctions.Add(blockMove);
			}
			
			moveFunctions.Add(playerMove);

			(var forward, var undo) = CreateDispatchPair(moveFunctions);
			
			undoStack.Push(undo);
			forward();
		}

		public void Undo()
		{
			if (undoStack.Any())
			{
				undoStack.Pop()();
			}
		}
		
		private void HandleMoveComplete()
		{
			Debug.Log("Move complete");
		}

		private (Func<MoveNotification>, Func<MoveNotification>) GenerateMovePair(LevelPoint from, LevelPoint to, MoveDirection direction)
		{
			var doFunc = GenerateMoveFunction(from, to, direction);
			var undoFunc = GenerateMoveFunction(to, from, direction.Invert());
			return (doFunc, undoFunc);
		}
		
		private Func<MoveNotification> GenerateMoveFunction(LevelPoint from, LevelPoint to, MoveDirection direction)
		{
			return () =>
			{
				var notification = new MoveNotification(level[from].Id, direction);
				level.Swap(from, to);
				return notification;
			};
		}

		private (Action, Action) CreateDispatchPair(IEnumerable<(Func<MoveNotification>, Func<MoveNotification>)> movePairs)
		{
			var forwardMoves = movePairs.Select(m => m.Item1);
			var undoMoves = movePairs.Select(m => m.Item2).Reverse();

			Action forward = () => DispatchMove(forwardMoves);
			Action undo = () => DispatchMove(undoMoves);

			return (forward, undo);
		}
		
		private void DispatchMove(IEnumerable<Func<MoveNotification>> moves)
		{
			var notifications = moves.Select(m => m.Invoke());
			OnMove?.Invoke(notifications, HandleMoveComplete);
		}
	}
}