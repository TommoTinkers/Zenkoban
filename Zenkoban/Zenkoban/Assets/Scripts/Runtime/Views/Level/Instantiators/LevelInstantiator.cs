using UnityEngine;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Views.Level.Objects;
using Object = UnityEngine.Object;

namespace Zenkoban.Runtime.Views.Level.Instantiators
{
	public static class LevelInstantiator
	{
		public static InstantiatedLevelView InstantiateLevel(Data.Levels.Level level, ILevelTheme levelTheme, Transform parent)
		{
			var size = level.Size;
			var positions = PositionGenerator.GeneratePositions(level);
			var blocks = new GameBlock[size.Width, size.Height];
			
			for (var x = 0; x < size.Width; x++)
			{
				for (var y = 0; y < size.Height; y++)
				{
					var position = positions[x, y];

					var tile = level.Tiles[x, y];
					var block = level.Blocks[x, y];

					if (tile.Type == TileType.Floor)
					{
						var floorPrefab = levelTheme.Floor[(x + y) % 2];
						var floor = Object.Instantiate(floorPrefab, position, Quaternion.identity);
						floor.transform.SetParent(parent, true);
					}

					if (tile.Type == TileType.Goal)
					{
						var goal = Object.Instantiate(levelTheme.Goal, position, Quaternion.identity);
						goal.transform.SetParent(parent, true);
					}

					GameBlock prefab = null;
					switch(block.Type)
					{
						case BlockType.Player:
							prefab = levelTheme.Player;
							break;
						case BlockType.Block:
							prefab = levelTheme.Block;
							break;
						case BlockType.Wall:
							prefab = levelTheme.Wall;
							break;
					}
					
					if(prefab != null)
					{
						var obj = Object.Instantiate(prefab, position + prefab.Offset, Quaternion.identity);
						obj.transform.SetParent(parent, true);
						obj.Id = block.Id;
						blocks[x, y] = obj;
					}
				}
			}
			
			return new InstantiatedLevelView(size, positions, blocks);
		}
	}
}