using UnityEngine;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Views.Level.Objects;
using Object = UnityEngine.Object;

namespace Zenkoban.Runtime.Views.Level.Instantiators
{
	public static class LevelInstantiator
	{
		public static void InstantiateLevel(Data.Levels.Level level, ILevelTheme levelTheme, Transform parent)
		{
			var size = level.Size;
			var positions = PositionGenerator.GeneratePositions(level);
			
			for (var x = 0; x < size.Width; x++)
			{
				for (var y = 0; y < size.Height; y++)
				{
					var position = positions[x, y];

					var tile = level.Tiles[x, y];
					var block = level.Blocks[x, y];

					if (tile.Type == TileType.Floor)
					{
						var obj = Object.Instantiate(levelTheme.Floor, position, Quaternion.identity);
						obj.transform.SetParent(parent, true);
					}

					if (block.Type == BlockType.Wall)
					{
						var obj = Object.Instantiate(levelTheme.Wall, position, Quaternion.identity);
						obj.transform.SetParent(parent, true);
					}
				}
			}
		}
	}
}