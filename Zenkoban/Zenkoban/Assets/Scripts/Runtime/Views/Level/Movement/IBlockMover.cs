using UnityEngine;

namespace Zenkoban.Runtime.Views.Level.Movement
{
	public interface IBlockMover
	{
		IBlockMover Move(GameObject obj, Vector3 to);
		BlockMovementAction Action();
	}
}