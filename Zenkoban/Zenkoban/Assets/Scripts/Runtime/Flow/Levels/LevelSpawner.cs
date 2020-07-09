using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Common.Mediators;
using Zenkoban.Runtime.Levels.Loading;

namespace Zenkoban.Runtime.Flow.Levels
{
	public class LevelSpawner : SerializedMonoBehaviour
	{
		[SerializeField]
		private LevelLogicViewMediator levelContextPrefab = null;
		
		[SerializeField]
		private ILevelLoader levelLoader = null;

		[SerializeField]
		private Transform spawnPoint = null;

		[SerializeField]
		private Transform despawnPoint = null;
		
		public LevelLogicViewMediator SpawnLevel(ILevelAsset levelAsset, Action<LevelLogicViewMediator> onLevelReady)
		{
			var context = Instantiate(levelContextPrefab);
			context.Initialise(levelLoader.Load(levelAsset));
			context.transform.position = spawnPoint.position;
			var anim = context.transform.DOMove(Vector3.zero, 0.5f);
			anim.onComplete += () => onLevelReady.Invoke(context);
			anim.Play();

			return context;
		}

		public void DeSpawnLevel(LevelLogicViewMediator context, Action onLevelDespawned)
		{
			var anim = context.transform.DOMove(despawnPoint.position, 0.5f);
			anim.onComplete += () => onLevelDespawned();
			anim.Play();
		}
	}
}