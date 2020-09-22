using UnityEngine.SceneManagement;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.Flow
{
	public static class SceneFlow
	{
		public static void LoadMainMenu()
		{
			SceneManager.LoadScene(GameSettings.MainMenuSceneName);
		}

		public static void LoadLevelSelect()
		{
			SceneManager.LoadScene(GameSettings.CarouselSceneName);
		}
	}
}