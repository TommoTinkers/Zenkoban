using System;
using Zenkoban.Data.Levels;
using Zenkoban.Extensions.Data.Levels;
using System.Linq;

namespace Zenkoban.Runtime.Data.Levels
{
	public class Level
	{
		public LevelSize Size { get; }
		public Block[,] Blocks { get; }
		public Tile[,] Tiles { get; }

		public Level(Block[,] blocks, Tile[,] tiles, LevelSize size)
		{
			Blocks = blocks;
			Tiles = tiles;
			Size = size;
			CheckLevelSize();
			CheckLevelNotNull();
		}

		private void CheckLevelNotNull()
		{
			if (Blocks == null)
			{
				throw new Exception("The provided blocks array is null.");
			}

			if (Tiles == null)
			{
				throw new Exception("The provided tiles array is null.");
			}
			
			var areThereNullBlocks =  Blocks.Cast<Block>().Any(b => b == null);
			var areThereNullTiles = Tiles.Cast<Tile>().Any(t => t == null);

			if (areThereNullBlocks)
			{
				throw new Exception($"The provided blocks array contains null values.");
			}

			if (areThereNullTiles)
			{
				throw new Exception($"The provided tiles array contains null values.");
			}
		}

		private void CheckLevelSize()
		{
			if (Size.Area() != Blocks.Length || Size.Area() != Tiles.Length)
			{
				throw new Exception($"Size of level is not valid. Expected: {Size.Area()}. Blocks: {Blocks.Length}. Tiles: {Tiles.Length}");
			}
		}

		public Block this[LevelPoint p]
		{
			get => Blocks[p.X, p.Y];
			set => Blocks[p.X, p.Y] = value;
		}

		public void Swap(LevelPoint a, LevelPoint b)
		{
			var temp = this[a];
			this[a] = this[b];
			this[b] = temp;
		}

		public Tile TileAt(LevelPoint p)
		{
			return Tiles[p.X, p.Y];
		}
	}
}