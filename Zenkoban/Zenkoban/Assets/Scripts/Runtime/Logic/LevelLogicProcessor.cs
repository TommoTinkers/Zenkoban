using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Common;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Extensions.Level;

namespace Zenkoban.Runtime.Logic
{
	public class LevelLogicProcessor : IMoveCommandProvider
	{
		public event Action<IEnumerable<MoveNotification>, Action> OnMove;
		
		private static readonly Dictionary<MoveDirection, LevelPoint> directionOffsets = new Dictionary<MoveDirection, LevelPoint>
		{
			{MoveDirection.Up, new LevelPoint(0, 1)},
			{MoveDirection.Down, new LevelPoint(0,  - 1)},
			{MoveDirection.Right, new LevelPoint(1, 0)},
			{MoveDirection.Left, new LevelPoint(- 1, 0)}
		};
		
		private readonly Level level;
		private readonly MoveValidator moveValidator;
		
		public LevelLogicProcessor(Level level)
		{
			this.level = level;
			moveValidator = new MoveValidator(level, directionOffsets);
		}

		public void Move(MoveDirection direction)
		{
			if (!moveValidator.Validate(level.FindPlayer(), direction)) return;
			
			var playerPos = level.FindPlayer();
			var playerDest = playerPos + directionOffsets[MoveDirection.Up];

			OnMove?.Invoke(new[] {new MoveNotification(level[playerPos].Id, direction),}, HandleMoveComplete);
			level.Swap(playerPos, playerDest);
		}

		private void HandleMoveComplete()
		{
			Debug.Log("Move complete");
		}
	}
}