using System;
using System.Collections.Generic;
using System.Linq;
using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Extensions;

namespace Zenkoban.Runtime.Logic
{
	public class MoveSequencer
	{
		private Level level;
		private List<ValueTuple<Func<MoveNotification>, Func<MoveNotification>>> moveFunctionPairs;
		private bool[,] reservations;

		public MoveSequencer(Level level)
		{
			this.level = level;
			reservations = new bool[level.Size.Width, level.Size.Height];
			moveFunctionPairs = new List<(Func<MoveNotification>, Func<MoveNotification>)>();
		}

		public void SequenceMove(LevelPoint from, LevelPoint to, MoveDirection direction)
		{
			if (reservations[to.X, to.Y])
			{
				return;
			}
			
			var functionPair = GenerateMovePair(from, to, direction);
			reservations[to.X, to.Y] = true;
			moveFunctionPairs.Add(functionPair);
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
		
		public ValueTuple<Action, Action> CreateDispatchPair(Action<IEnumerable<MoveNotification>> notifier)
		{
			var forwardMoves =moveFunctionPairs.Select(m => m.Item1);
			var undoMoves = moveFunctionPairs.Select(m => m.Item2).Reverse();

			Action forward = () => notifier(DispatchMove(forwardMoves));
			Action undo = () => notifier(DispatchMove(undoMoves));

			return (forward, undo);
		}

		private IEnumerable<MoveNotification> DispatchMove(IEnumerable<Func<MoveNotification>> moves)
		{
			return moves.Select(m => m.Invoke());
		}
	}
}