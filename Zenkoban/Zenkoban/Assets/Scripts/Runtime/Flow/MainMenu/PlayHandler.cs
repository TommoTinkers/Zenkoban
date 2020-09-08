using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zenkoban.Runtime.Flow.MainMenu
{
	public class PlayHandler : MonoBehaviour
	{
		private const string CAROUSEL_SCENE = "Carousel";

		public void HandlePlaySelected()
		{
			SceneManager.LoadScene(CAROUSEL_SCENE);
		}
	}
}