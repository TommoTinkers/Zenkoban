using UnityEngine;
using UnityEngine.SceneManagement;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.Flow.MainMenu
{
	public class PlayHandler : MonoBehaviour
	{
		public void HandlePlaySelected()
		{
			SceneManager.LoadScene(GameSettings.CarouselSceneName);
		}
	}
}