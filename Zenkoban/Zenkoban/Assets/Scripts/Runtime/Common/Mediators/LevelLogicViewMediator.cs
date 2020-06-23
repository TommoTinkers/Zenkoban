using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Levels.Loading;
using Zenkoban.Runtime.Logic;
using Zenkoban.Runtime.Views.Level;
using Zenkoban.Runtime.Views.Level.Factories;

namespace Zenkoban.Runtime.Common.Mediators
{
	public class LevelLogicViewMediator : SerializedMonoBehaviour
	{
		[SerializeField]
		private ILevelAsset levelAsset = null;

		[SerializeField]
		private ILevelLoader levelLoader = null;

		[SerializeField]
		private ILevelTheme levelTheme = null;

		private IInstantiatedLevelViewFactory instantiatedLevelViewFactory;
		private LevelLogicProcessor logicProcessor;

		private void Awake()
		{
			var level = levelLoader.Load(levelAsset);
			logicProcessor = new LevelLogicProcessor(level);
			instantiatedLevelViewFactory = new InstantiatedLevelViewFactory(levelTheme, transform);
			var viewData = instantiatedLevelViewFactory.Construct(level);
			new LevelView(viewData, logicProcessor);
		}

		[Button]
		private void MoveUp()
		{
			logicProcessor.MoveUp();
		}
	}
}