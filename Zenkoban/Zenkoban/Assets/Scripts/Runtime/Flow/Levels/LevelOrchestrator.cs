using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;
using Zenkoban.Assets.Levels;
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
		
		private LevelProvider levelProvider;
		
		private void Awake()
		{
			levelProvider = new LevelProvider(LevelManager.SetIndex, LevelManager.LevelIndex, levelSets);
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
			levelProvider.Cycle();
			PlayCurrentLevel();
		}

		private void PlayLevel(ILevelAsset level) => currentLevelContext = levelSpawner.SpawnLevel(level, BeginLevel);
		private void PlayCurrentLevel() => PlayLevel(levelProvider.CurrentLevel);
		private void DespawnLevel(Action then) => levelSpawner.DeSpawnLevel(currentLevelContext, then);
		private void BeginLevel(IBeginnableLevelContext context) => context.Begin(HandleLevelCompleted);
		
		private void HandleLevelCompleted()
		{
			switch(levelProvider.GetProgressionStatus())
			{
				case LevelProgressionStatus.Ok:
					endOfLevelChoiceProvider.GetChoice(HandlePlayerChoiceMade);
					break;
				case LevelProgressionStatus.EndOfSet:
					Debug.Log("End of set");
					endOfLevelChoiceProvider.GetChoice(HandlePlayerChoiceMade);
					break;
				case LevelProgressionStatus.EndOfGame:
					Debug.Log("End of game");
					ReturnHome();
					break;
			}
		}
	}
}