using UnityEngine;
using UnityEngine.SceneManagement;
using Zenkoban.Runtime.Flow.Levels;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.Flow.MainMenu
{
	public class LinearGameStart : MonoBehaviour
	{
		public void StartLinearGame()
		{
			LevelManager.SetIndex = 0;
			LevelManager.LevelIndex = 0;
			SceneManager.LoadScene(GameSettings.GameSceneName);
		}
	}
}