using System.Linq;
using Zenkoban.Assets.Levels;
using Zenkoban.Extensions.Data.Levels;

namespace Zenkoban.Assets.Flow.Levels
{
	public enum LevelProgressionStatus
	{
		Ok,
		EndOfSet,
		EndOfGame
	}
	
	public class LevelProvider
	{
		private int currentSet;
		private int currentLevel;

		private GameLevelsConfiguration gameLevels;
		
		public LevelProvider(int currentSet, int currentLevel, GameLevelsConfiguration gameLevels)
		{
			gameLevels.AssetIsValid();
			this.currentSet = currentSet;
			this.currentLevel = currentLevel;
			this.gameLevels = gameLevels;
		}

		public LevelProgressionStatus GetProgressionStatus()
		{
			var set = gameLevels.MainLevels[currentSet];
			var nextLevelIndex = currentLevel + 1;
			
			if (nextLevelIndex < set.AllLevels.Count())
			{
				return LevelProgressionStatus.Ok;
			}

			var nextSetIndex = currentSet + 1;
			return nextSetIndex < gameLevels.MainLevels.Count()
				? LevelProgressionStatus.EndOfSet
				: LevelProgressionStatus.EndOfGame;

		}
		
		public LevelProgressionStatus Cycle()
		{
			var set = gameLevels.MainLevels[currentSet];
			currentLevel++;

			if (currentLevel < set.AllLevels.Count())
			{
				return LevelProgressionStatus.Ok;
			}

			currentSet++;
			currentLevel = 0;
			return currentSet < gameLevels.MainLevels.Count() ? LevelProgressionStatus.EndOfSet : LevelProgressionStatus.EndOfGame;
		}

		public ILevelAsset CurrentLevel => gameLevels.MainLevels[currentSet][currentLevel];
	}
}