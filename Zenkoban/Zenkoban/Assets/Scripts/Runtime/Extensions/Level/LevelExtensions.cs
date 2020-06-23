using System;
using Zenkoban.Data.Levels;
using Zenkoban.Extensions.Utility;
using Zenkoban.Runtime.Data.Levels;

namespace Zenkoban.Runtime.Extensions.Level
{
	public static class LevelExtensions 
	{
		public static LevelPoint FindPlayer(this Data.Levels.Level level)
		{
			(var x,var y) = level.Blocks.IndexOf(p => p.Type == BlockType.Player);
			
			if (x == -1 || y == -1)
			{
				throw new Exception("No player in the level.");
			}
			
			return new LevelPoint(x, y);
		}
	}
}