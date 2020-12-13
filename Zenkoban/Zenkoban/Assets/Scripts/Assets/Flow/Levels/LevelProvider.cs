using System.Linq;
using Zenkoban.Assets.Levels;
using Zenkoban.Extensions.Data.Levels;

namespace Zenkoban.Assets.Flow.Levels
{
	public enum LevelCycleEvent
	{
		Ok,
		Ok_EndOfSet,
		Ok_EndOfGame
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

		public LevelCycleEvent Cycle()
		{
			var set = gameLevels.MainLevels[currentSet];
			
			currentLevel++;

			if (currentLevel < set.AllLevels.Count())
			{
				return LevelCycleEvent.Ok;
			}

			currentSet++;
			currentLevel = 0;
			return currentSet < gameLevels.MainLevels.Count() ? LevelCycleEvent.Ok_EndOfSet : LevelCycleEvent.Ok_EndOfGame;
		}

		public ILevelAsset CurrentLevel => gameLevels.MainLevels[currentSet][currentLevel];
	}
}