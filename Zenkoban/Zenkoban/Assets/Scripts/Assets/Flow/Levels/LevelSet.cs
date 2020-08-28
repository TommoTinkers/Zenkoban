using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;

namespace Zenkoban.Assets.Flow.Levels
{
	[CreateAssetMenu(fileName = "LevelSet", menuName = "Zenkoban/Game/Level Set")]
	public class LevelSet : SerializedScriptableObject
	{
		[SerializeField]
		private LevelAsset fallbackLevel = null;
		
		[SerializeField]
		private LevelAsset[] levels = null;

		[SerializeField] 
		private LevelAsset[] bonusLevels = null;

		public LevelAsset FallbackLevel => fallbackLevel;

		public LevelAsset[] Levels => levels;

		public LevelAsset[] BonusLevels => bonusLevels;
	}
}