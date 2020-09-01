using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Zenkoban.Assets.Flow.Levels
{
	[CreateAssetMenu(fileName = "LevelSet", menuName = "Zenkoban/Game/Game Levels Configuration")]
	public class GameLevelsConfiguration : SerializedScriptableObject
	{
		[SerializeField]
		private LevelSet[] mainLevels = null;

		public IReadOnlyList<LevelSet> MainLevels => mainLevels;
	}
}