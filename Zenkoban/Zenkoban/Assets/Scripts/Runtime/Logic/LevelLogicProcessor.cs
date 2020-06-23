using System;
using System.Collections.Generic;
using UnityEngine;
using Zenkoban.Runtime.Common;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Extensions.Level;

namespace Zenkoban.Runtime.Logic
{
	public class LevelLogicProcessor : IMoveCommandProvider
	{
		public event Action<IEnumerable<MoveNotification>, Action> OnMove;
		
		private readonly Level level;
		
		public LevelLogicProcessor(Level level)
		{
			this.level = level;
		}

		public void MoveUp()
		{
			var playerPosition = level.FindPlayer();

			level.Blocks[playerPosition.X, playerPosition.Y + 1] = level.Blocks[playerPosition.X, playerPosition.Y];
			var id = level.Blocks[playerPosition.X, playerPosition.Y + 1].Id;
			var notification = new MoveNotification(id, MoveDirection.Up);
			OnMove?.Invoke(new []{ notification}, HandleMoveComplete);
		}

		private void HandleMoveComplete()
		{
			Debug.Log("LOGIC: Move complete");
		}
	}
}