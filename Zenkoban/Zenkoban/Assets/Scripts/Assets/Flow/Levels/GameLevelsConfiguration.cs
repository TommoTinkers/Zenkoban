using Sirenix.OdinInspector;
using UnityEngine;

namespace Zenkoban.Assets.Flow.Levels
{
	[CreateAssetMenu(fileName = "LevelSet", menuName = "Zenkoban/Game/Game Levels Configuration")]
	public class GameLevelsConfiguration : SerializedScriptableObject
	{
		[SerializeField]
		private LevelSet[] _mainLevels;

		[SerializeField]
		private LevelEntry[] _secretLevels;
	}
}