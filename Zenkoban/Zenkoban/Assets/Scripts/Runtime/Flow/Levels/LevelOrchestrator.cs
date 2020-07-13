using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Common.Mediators;

namespace Zenkoban.Runtime.Flow.Levels
{
	public class LevelOrchestrator : SerializedMonoBehaviour
	{
		[SerializeField]
		private LevelSpawner levelSpawner = null;
		
		[SerializeField]
		private ILevelAsset levelAsset = null;

		private LevelLogicViewMediator currentLevelContext;
		
		private void Awake()
		{
			PlayNextLevel();
		}

		private void HandleLevelComplete()
		{
			levelSpawner.DeSpawnLevel(currentLevelContext, PlayNextLevel);
		}

		private void PlayNextLevel()
		{
			currentLevelContext = levelSpawner.SpawnLevel(levelAsset, c => c.Begin(HandleLevelComplete));
		}
	}
}