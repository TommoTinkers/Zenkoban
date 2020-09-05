using System;

namespace Zenkoban.Input.Movement
{
	public interface ILinearMenuInputProvider
	{
		event Action OnUp;
		event Action OnDown;
		event Action OnSelect;
	}
}