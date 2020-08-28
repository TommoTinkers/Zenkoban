using System;

namespace Zenkoban.Input.Movement
{
	public interface ICarouselInputProvider
	{
		event Action OnCycleLeft;
		event Action OnCycleRight;
		event Action OnSelect;
		event Action OnBack;
	}
}