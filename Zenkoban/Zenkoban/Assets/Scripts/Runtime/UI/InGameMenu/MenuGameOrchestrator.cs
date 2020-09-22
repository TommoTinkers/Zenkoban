using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Input.Movement;
using Zenkoban.Runtime.Common.Mediators;

namespace Zenkoban.Runtime.UI.InGameMenu
{
	public class MenuGameOrchestrator : SerializedMonoBehaviour
	{
		[SerializeField]
		private IActivatable levelLogicViewMediator = null;

		[SerializeField]
		private IMovementInputProvider movementInputProvider = null;
		
		[SerializeField]
		private IActivatable inGameMenu = null;

		private void Awake()
		{
			inGameMenu.SetInactive();
			movementInputProvider.OnMenu += EnableMenu;
		}

		private void EnableMenu()
		{
			levelLogicViewMediator.SetInactive();
			inGameMenu.SetActive();
		}

		public void ReturnToGame()
		{
			inGameMenu.SetInactive();
			levelLogicViewMediator.SetActive();
		}
	}
}