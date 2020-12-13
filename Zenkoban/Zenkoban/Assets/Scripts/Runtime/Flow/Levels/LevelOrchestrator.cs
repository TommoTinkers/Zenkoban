using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;
using Zenkoban.Runtime.Common.Mediators;
using Zenkoban.Runtime.Flow.Levels.EndOfLevel;

namespace Zenkoban.Runtime.Flow.Levels
{
	public class LevelOrchestrator : SerializedMonoBehaviour
	{
		[SerializeField]
		private GameLevelsConfiguration levelSets = null;

		[SerializeField]
		private LevelSpawner levelSpawner = null;

		[SerializeField]
		private IEndOfLevelChoiceProvider endOfLevelChoiceProvider = null;

		private LevelLogicViewMediator currentLevelContext;

		private LevelSet currentset;
		private int currentLevel;

		private void Awake()
		{
			currentset = levelSets.MainLevels[LevelManager.SetIndex];
			currentLevel = LevelManager.LevelIndex;
			PlayCurrentLevel();
		}
		
		private void HandlePlayerChoiceMade(EndOfLevelChoice choice)
		{
			switch (choice)
			{
				case EndOfLevelChoice.Repeat:
					DespawnLevel(PlayCurrentLevel);
					break;
				case EndOfLevelChoice.Next:
					DespawnLevel(PlayNextLevel);
					break;
				case EndOfLevelChoice.Home:
					DespawnLevel(ReturnHome);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private static void ReturnHome()
		{
			SceneFlow.LoadMainMenu();
		}

		private void PlayNextLevel()
		{
			currentLevel++;
			PlayCurrentLevel();
		}

		private void PlayCurrentLevel() => currentLevelContext = levelSpawner.SpawnLevel(currentset[currentLevel], BeginLevel);
		
		private void DespawnLevel(Action then) => levelSpawner.DeSpawnLevel(currentLevelContext, then);
		private void BeginLevel(IBeginnableLevelContext context) => context.Begin(GetEndOfLevelPlayerChoice);
		private void GetEndOfLevelPlayerChoice() => endOfLevelChoiceProvider.GetChoice(HandlePlayerChoiceMade);
	}
}