using System;
using UnityEngine;

namespace Zenkoban.Input.Movement
{
	public interface IEndOfLevelMenuInputProvider
	{
		event Action OnContinue;
		event Action OnReplay;
		event Action OnHome;
	}

	class EndOfLevelMenuInputProvider : MonoBehaviour, IEndOfLevelMenuInputProvider
	{
		private Controls controls;
		public event Action OnContinue;
		public event Action OnReplay;
		public event Action OnHome;

		private void Awake()
		{
			controls = new Controls();
			controls.EndOfLevel.Continue.performed += a => OnContinue?.Invoke();
			controls.EndOfLevel.Replay.performed += a => OnReplay?.Invoke();
			controls.EndOfLevel.Home.performed += a => OnHome?.Invoke();
		}
		
		private void OnEnable()
		{
			controls.Enable();
		}

		private void OnDisable()
		{
			controls.Disable();
		}
	}
}