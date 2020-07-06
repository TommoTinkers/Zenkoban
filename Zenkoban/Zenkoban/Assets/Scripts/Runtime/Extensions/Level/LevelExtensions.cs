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
		
		public static bool IsWall(this Data.Levels.Level level, LevelPoint point) => level[point].Type == BlockType.Wall;

		public static int OpenGoalSquares(this Data.Levels.Level level)
		{
			var count = 0;
			for (var x = 0; x < level.Size.Width; x++)
			{
				for (var y = 0; y < level.Size.Height; y++)
				{
					if (level.Tiles[x, y].Type != TileType.Goal) continue;
					if (level.Blocks[x, y].Type != BlockType.Block)
					{
						count++;
					}
				}
			}

			return count;
		}
	}
}