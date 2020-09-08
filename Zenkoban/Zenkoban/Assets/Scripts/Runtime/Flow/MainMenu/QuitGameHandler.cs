using UnityEngine;

namespace Zenkoban.Runtime.Flow.MainMenu
{
	public class QuitGameHandler : MonoBehaviour
	{
		public void QuitGame()
		{
			Application.Quit();
		}
	}
}