using System;
using System.Collections.Generic;
using UnityEngine;
using Zenkoban.Runtime.Common;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Views.Level.Instantiators;
using Zenkoban.Runtime.Views.Level.Movement;
using Zenkoban.Settings;


namespace Zenkoban.Runtime.Views.Level
{
	public class LevelView
	{
		private readonly InstantiatedLevelView level;

		public LevelView(InstantiatedLevelView instantiatedLevelView, IMoveCommandProvider moveCommandProvider)
		{
			level = instantiatedLevelView;
			moveCommandProvider.OnMove += HandleMove;
		}

		private void HandleMove(IEnumerable<MoveNotification> moveNotifications, Action onCompleteCallback)
		{
			var mover = new SimpleBlockMoverFactory().Get();
			
			foreach (var move in moveNotifications)
			{
				var block = level.Blocks[move.Id];
				mover.Move(block.gameObject,GetMoveToPosition(block.transform.position, move.Direction));
			}
			
			mover.Action().Start(() => OnMoveEnded(onCompleteCallback));
		}

		private void OnMoveEnded(Action callback)
		{
			callback?.Invoke();
		}

		private Vector3 GetMoveToPosition(Vector3 current, MoveDirection direction)
		{
			switch(direction)
			{
				case MoveDirection.Left:
					return current + Vector3.left * GameSettings.TileSize;
				case MoveDirection.Up:
					return current + Vector3.forward * GameSettings.TileSize;
				case MoveDirection.Right:
					return current + Vector3.right * GameSettings.TileSize;
				case MoveDirection.Down:
					return current + Vector3.back * GameSettings.TileSize;
				default:
					throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
			}
		}
	}
}