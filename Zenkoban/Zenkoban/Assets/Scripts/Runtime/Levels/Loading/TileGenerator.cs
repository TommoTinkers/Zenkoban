using System.Collections.Generic;
using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Data.Levels;
using AssetTileType = Zenkoban.Assets.Levels.TileType;
using TileType = Zenkoban.Runtime.Data.Levels.TileType;

namespace Zenkoban.Runtime.Levels.Loading
{
	public class TileGenerator : ITileGenerator
	{
		private static readonly Dictionary<AssetTileType, TileType> TileMap = new Dictionary<AssetTileType, TileType>
		{
			{AssetTileType.Wall, TileType.Empty},
			{AssetTileType.Empty, TileType.Empty},
			{AssetTileType.Floor, TileType.Floor},
			{AssetTileType.Goal, TileType.Goal},
			{AssetTileType.BlockOnGoal, TileType.Goal},
			{AssetTileType.Block, TileType.Floor},
			{AssetTileType.Player, TileType.Floor}
		};
			
		public Tile[,] Generate(ILevelAsset level)
		{
			var width = level.Size.Width;
			var height = level.Size.Height;
			
			var tiles = new Tile[width, height];

			for (var x = 0; x < width; x++)
			{
				for (var y = 0; y < height; y++)
				{
					var asset = level.Tiles[x, y];
					tiles[x, y] = new Tile(TileMap[asset]);
				}
			}

			return tiles;
		}
	}
}