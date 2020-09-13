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
			PlayCurrentLevel();
		}

		private void PlayNextLevel()
		{
			currentLevel++;
			PlayCurrentLevel();
		}


		private void PlayCurrentLevel() => currentLevelContext = levelSpawner.SpawnLevel(currentset[currentLevel], HandleLevelReady);
		private void HandleLevelDespawned() => PlayNextLevel();

		private void HandleLevelReady(IBeginnableLevelContext context)
		{
			context.Begin(HandleLevelComplete);
		}

		private void HandleLevelComplete()
		{
			levelSpawner.DeSpawnLevel(currentLevelContext, HandleLevelDespawned);
		}
	}
}