using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Zenkoban.Data.Levels;
using Zenkoban.Extensions.Utility;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Extensions.Blocks;

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
		
		public static LevelPoint FindBlock(this Data.Levels.Level level, Block block)
		{
			(var x,var y) = level.Blocks.IndexOf(p => p == block);
			
			if (x == -1 || y == -1)
			{
				throw new Exception("Block not found");
			}
			
			return new LevelPoint(x, y);
		}

		
		public static bool IsWall(this Data.Levels.Level level, LevelPoint point) => level[point].Type == BlockType.Wall;
		public static bool IsNone(this Data.Levels.Level level, LevelPoint point) => level[point].Type == BlockType.None;

		public static int CountOpenGoalSquares(this Data.Levels.Level level)
		{
			var count = 0;
			for (var x = 0; x < level.Size.Width; x++)
			{
				for (var y = 0; y < level.Size.Height; y++)
				{
					if (level.Tiles[x, y].Type != TileType.Goal) continue;
					
					var blockType = level.Blocks[x, y].Type;
					if (blockType == BlockType.None || blockType == BlockType.Player)
					{
						count++;
					}
				}
			}

			return count;
		}

		public static IEnumerable<Block> AllPushables(this Data.Levels.Level level)
		{
			return level.AllBlocks().Where(b => b.IsPushable());
		}

		public static IEnumerable<Block> AllBlocksOfType(this Data.Levels.Level level, BlockType type) => level.AllBlocks().Where(b => b.Type == type);

		public static IEnumerable<Block> BlocksOnGoals(this Data.Levels.Level level)
		{
			for (var x = 0; x < level.Size.Width; x++)
			{
				for (var y = 0; y < level.Size.Height; y++)
				{
					var tile = level.Tiles[x, y];
					var block = level.Blocks[x, y];
					
					if (tile.Type != TileType.Goal) continue;
					
					if (block.Type != BlockType.None || block.Type != BlockType.Player)
					{
						yield return block;
					}
				}
			}
		}

		public static IEnumerable<Block> AllOtherMirrorBlocks(this Data.Levels.Level level, Block block)
		{
			return level.AllBlocksOfType(BlockType.MirrorBlock).Except(new []{ block });
		}

		public static IEnumerable<Block> AllBlocks(this Data.Levels.Level level)
		{
			for (var x = 0; x < level.Size.Width; x++)
			{
				for (var y = 0; y < level.Size.Height; y++)
				{
					var block = level.Blocks[x, y];
					if (block.Type != BlockType.None)
					{
						yield return block;
					}
				}
			}
		}
	}
}