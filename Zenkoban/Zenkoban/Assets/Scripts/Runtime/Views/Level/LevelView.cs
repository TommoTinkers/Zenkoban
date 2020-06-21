using Zenkoban.Runtime.Views.Level.Instantiators;
using Zenkoban.Runtime.Views.Level.Objects;

namespace Zenkoban.Runtime.Views.Level
{
	public class LevelView
	{
		private GameBlock[,] Blocks => level.Blocks;
		private readonly InstantiatedLevelView level;

		public LevelView(InstantiatedLevelView instantiatedLevelView)
		{
			level = instantiatedLevelView;
		}
	}
}