using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;
using Zenkoban.Runtime.Common.Mediators;

namespace Zenkoban.Runtime.Flow.Levels
{
	public class LevelOrchestrator : SerializedMonoBehaviour
	{
		[SerializeField]
		private GameLevelsConfiguration levelSets = null;
		[SerializeField]
		private LevelSpawner levelSpawner = null;
		
		private LevelLogicViewMediator currentLevelContext;

		private LevelSet currentset;
		private int currentLevel;
		
		private void Awake()
		{
			currentset = levelSets.MainLevels[LevelManager.SetIndex];
			currentLevel = LevelManager.LevelIndex;
			PlayNextLevel();
		}

		private void HandleLevelComplete()
		{
			currentLevel++;
			levelSpawner.DeSpawnLevel(currentLevelContext, PlayNextLevel);
		}

		private void PlayNextLevel()
		{
			currentLevelContext = levelSpawner.SpawnLevel(currentset[currentLevel], c => c.Begin(HandleLevelComplete));
		}
	}
}