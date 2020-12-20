using System;
using System.Collections.Generic;
using System.Linq;
using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;

namespace Zenkoban.Runtime.Logic
{
	public class MoveSequencer
	{
		private readonly Level level;
		private readonly List<ValueTuple<Func<MoveNotification>, Func<MoveNotification>>> moveFunctionPairs;
		private readonly bool[,] reservations;
		
		public MoveSequencer(Level level)
		{
			this.level = level;
			reservations = new bool[level.Size.Width, level.Size.Height];
			moveFunctionPairs = new List<(Func<MoveNotification>, Func<MoveNotification>)>();
		}

		public void SequenceMove(LevelPoint from, LevelPoint to)
		{
			if (reservations[to.X, to.Y])
			{
				return;
			}
			
			var functionPair = GenerateMovePair(from, to);
			reservations[to.X, to.Y] = true;
			moveFunctionPairs.Add(functionPair);
		}
		
		private (Func<MoveNotification>, Func<MoveNotification>) GenerateMovePair(LevelPoint from, LevelPoint to)
		{
			var doFunc = GenerateMoveFunction(from, to);
			var undoFunc = GenerateMoveFunction(to, from);
			return (doFunc, undoFunc);
		}
		
		private Func<MoveNotification> GenerateMoveFunction(LevelPoint from, LevelPoint to)
		{
			return () =>
			{
				var delta = to - from;
				var notification = new MoveNotification(level[from].Id, delta);
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