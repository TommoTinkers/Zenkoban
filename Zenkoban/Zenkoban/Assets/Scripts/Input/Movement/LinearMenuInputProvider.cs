using System;
using Sirenix.OdinInspector;

namespace Zenkoban.Input.Movement
{
	public class LinearMenuInputProvider : SerializedMonoBehaviour, ILinearMenuInputProvider
	{
		private Controls controls;

		public event Action OnUp;
		public event Action OnDown;
		public event Action OnSelect;
		
		private void Awake()
		{
			controls = new Controls();
			var menuControls = controls.LinearMenu;

			menuControls.Up.performed += c => OnUp?.Invoke();
			menuControls.Down.performed += c => OnDown?.Invoke();
			menuControls.Select.performed += c => OnSelect?.Invoke();
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