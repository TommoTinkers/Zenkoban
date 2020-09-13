using System;
using Zenkoban.Runtime.Views.Level.Extensions;

namespace Zenkoban.Runtime.Views.Level.PostMove
{
	public class PostMoveLevelView
	{
		public static void Process(Data.Levels.Level level, Action onComplete, InstantiatedLevelView levelInstance)
		{
			var gameBlocksOnGoal = levelInstance.BlocksOnGoals(level);
			var gameBlocksNotOnGoal = levelInstance.BlocksNotOnGoal(level);
			
			foreach (var colorable in gameBlocksOnGoal)
			{
				colorable.ColorToOnGoal();	
			}

			foreach (var colorable in gameBlocksNotOnGoal)
			{
				colorable.ColorToOffGoal();
			}
			
			onComplete?.Invoke();
		}
	}
}