using System.Collections.Generic;
using System.Linq;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Extensions.Level;
using Zenkoban.Runtime.Views.Level.Objects;

namespace Zenkoban.Runtime.Views.Level.Extensions
{
	public static class InstantiatedLevelViewExtensions
	{
		public static IEnumerable<ColorableGoalBlock> BlocksOnGoals(this InstantiatedLevelView levelInstance, Data.Levels.Level level)
		{
			var blocksOnGoal = level.BlocksOnGoals().ToArray();

			return levelInstance.FindBlocksById(blocksOnGoal);
		}

		public static IEnumerable<ColorableGoalBlock> BlocksNotOnGoal(this InstantiatedLevelView levelInstance, Data.Levels.Level level)
		{
			var blocksNotOnGoal = level.AllPushables().Except(level.BlocksOnGoals());
			return levelInstance.FindBlocksById(blocksNotOnGoal);
		}
		
		private static IEnumerable<ColorableGoalBlock> FindBlocksById(this InstantiatedLevelView levelInstance, IEnumerable<Block> blocks)
		{
			return levelInstance.Blocks
				.Where(kvp => blocks.Select(b => b.Id).Contains(kvp.Key))
				.Select(kvp => kvp.Value.gameObject.GetComponent<ColorableGoalBlock>())
				.Where(c => c != null);
		}
	}
}