using System.Collections.Generic;
using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Data.Levels;
using TileType = Zenkoban.Assets.Levels.TileType;

namespace Zenkoban.Runtime.Levels.Loading
{
	public class BlockGenerator : IBlockGenerator
	{
		private static readonly Dictionary<TileType, BlockType> BlockMap = new Dictionary<TileType, BlockType>
		{
			{TileType.Empty, BlockType.None},
			{TileType.Floor, BlockType.None},
			{TileType.Goal, BlockType.None},
			{TileType.Block, BlockType.Block},
			{TileType.Player, BlockType.Player},
			{TileType.Wall, BlockType.Wall},
			{TileType.BlockOnGoal, BlockType.Block}
		};
		
		public Block[,] Generate(ILevelAsset level)
		{
			var width = level.Size.Width;
			var height = level.Size.Height;
			
			var blocks = new Block[width, height];

			for (var x = 0; x < width; x++)
			{
				for (var y = 0; y < height; y++)
				{
					var asset = level.Tiles[x, y];
					blocks[x,y] = new Block(BlockMap[asset]);
				}
			}

			return blocks;
		}
	}
}