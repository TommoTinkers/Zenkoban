using DG.Tweening;
using UnityEngine;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.Views.Level.Movement
{
	public class BlockMover : IBlockMover
	{
		private readonly BlockMovementAction currentAction = new BlockMovementAction();

		public IBlockMover Move(GameObject obj, Vector3 to)
		{
			var duration = GameSettings.BlockMoveDuration;
			var abosluteTo = new Vector3(to.x, obj.transform.position.y, to.z);
			var anim = obj.transform.DOLocalMove(abosluteTo, duration).Pause();
			currentAction.Add(anim);
			return this;
		}

		public BlockMovementAction Action()
		{
			return currentAction;
		}
	}
}