using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;
using Zenkoban.Extensions.Utility.Collections;
using Zenkoban.Settings;

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

		public LevelAsset this[int index]
		{
			get
			{
				if (index < GameSettings.StandardLevelsPerSet)
				{
					if (levels.IsValidIndex(index))
					{
						return levels[index];
					}

					return fallbackLevel;
				}

				if (index < GameSettings.StandardLevelsPerSet + GameSettings.BonusLevelsPerSet)
				{
					if (bonusLevels.IsValidIndex(index))
					{
						return bonusLevels[index];
					}

					return fallbackLevel;
				}

				return fallbackLevel;
			}
		}

		public IEnumerable<LevelAsset> AllLevels()
		{
			for (var x = 0; x < GameSettings.TotalLevelsPerSet; x++)
			{
				yield return this[x];
			}
		}
	}
}