using UnityEngine;

namespace Zenkoban.Runtime.Flow.MainMenu
{
	public class LevelSelectLoader : MonoBehaviour
	{
		public void HandlePlaySelected() => SceneFlow.LoadLevelSelect();
	}
}