using System;
using UnityEngine;

namespace Zenkoban.Input.Movement
{
	public class MovementInputProvider : MonoBehaviour, IMovementInputProvider
	{
		public event Action OnMoveLeft;
		public event Action OnMoveRight;
		public event Action OnMoveUp;
		public event Action OnMoveDown;
		public event Action OnUndo;
		public event Action OnMenu;
		
		private Controls controls;
		
		private void Awake()
		{
			controls = new Controls();
			controls.InGame.MoveLeft.performed += a => OnMoveLeft?.Invoke();
			controls.InGame.MoveRight.performed += a => OnMoveRight?.Invoke();
			controls.InGame.MoveUp.performed += a => OnMoveUp?.Invoke();
			controls.InGame.MoveDown.performed += a => OnMoveDown?.Invoke();
			controls.InGame.Undo.performed += a => OnUndo?.Invoke();
			controls.InGame.Menu.performed += a => OnMenu?.Invoke();
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