using System;

namespace Zenkoban.Input.Movement
{
	public interface IMovementInputProvider
	{
		event Action OnMoveLeft;
		event Action OnMoveRight;
		event Action OnMoveUp;
		event Action OnMoveDown;
		event Action OnUndo;
		event Action OnMenu;
	}
}