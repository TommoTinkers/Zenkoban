using System;

namespace Zenkoban.Input.Movement
{
	public interface IEndOfLevelMenuInputProvider
	{
		event Action OnContinue;
		event Action OnReplay;
		event Action OnHome;
	}
}