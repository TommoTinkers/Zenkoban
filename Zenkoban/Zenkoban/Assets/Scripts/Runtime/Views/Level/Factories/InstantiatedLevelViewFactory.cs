using UnityEngine;
using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Levels.Loading;
using Zenkoban.Runtime.Views.Level.Instantiators;

namespace Zenkoban.Runtime.Views.Level.Factories
{
	public class InstantiatedLevelViewFactory : IInstantiatedLevelViewFactory
	{
		private readonly ILevelLoader levelLoader;
		private readonly ILevelTheme levelTheme;
		private readonly Transform parent;

		public InstantiatedLevelViewFactory(ILevelTheme levelTheme, Transform parent)
		{
			this.levelTheme = levelTheme;
			this.parent = parent;
		}
		
		public InstantiatedLevelView Construct(Data.Levels.Level level )
		{
			var levelData = LevelInstantiator.InstantiateLevel(level, levelTheme, parent);
			return levelData;
		}
	}
}