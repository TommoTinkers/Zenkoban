using System;
using UnityEngine;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.Views.Level
{
	public static class PositionGenerator
	{
		public static Vector3[,] GeneratePositions(Data.Levels.Level level)
		{
			var size = level.Size;
			
			var centeringOffset = FindCenteringOffset(level);
			
			var tileSize = GameSettings.TileSize;
			var tilePositions = new Vector3[size.Width, size.Height];
			
			var xPos = 0f;
			var yPos = 0f;
			
			for (var x = 0; x < size.Width; x++)
			{
				for (var y = 0; y < size.Height; y++)
				{
					tilePositions[x, y] = new Vector3(xPos, 0f, yPos) - centeringOffset;
					yPos += tileSize;
				}
				
				yPos = 0f;
				xPos += tileSize;
			}

			return tilePositions;
		}

		private static Vector3 FindCenteringOffset(Data.Levels.Level level)
		{
			var halfTileSize = new Vector3(GameSettings.TileSize / -2f, 0f, GameSettings.TileSize / -2f);
			
			var excessAtStart = CalculateExcessAtStart(level);
			var excessAtEnd = CalculateExcessAtEnd(level);

			
			var levelSizeX = level.Size.Width - ( excessAtEnd.x + excessAtStart.x);
			var levelSizeY = level.Size.Height - (excessAtEnd.z + excessAtStart.z);
			
			var startExcessOffset = new Vector3(excessAtStart.x, 0f, excessAtStart.z) * GameSettings.TileSize;
			
			var levelSizeOffset = new Vector3(levelSizeX / 2f, 0f, levelSizeY / 2f) * GameSettings.TileSize;
			
			return levelSizeOffset + startExcessOffset + halfTileSize;
		}

		private static Vector3 CalculateExcessAtStart(Data.Levels.Level level)
		{
			var y = CalculateExcessAtStartY(level);
			var x = CalculateExcessAtStartX(level);
			
			return new Vector3(x, 0, y);
		}

		private static float CalculateExcessAtStartY(Data.Levels.Level level)
		{
			var blankXRows = 0;
			var size = level.Size;
			for (var y = 0; y < size.Height; y++)
			{
				for (var x = 0; x < size.Width; x++)
				{
					if (level.Blocks[x, y].Type != BlockType.None)
					{
						return blankXRows;
					}
				}

				blankXRows++;
			}
			
			throw new Exception("No blocks in level");
		}

		private static float CalculateExcessAtStartX(Data.Levels.Level level)
		{
			var blankYRows = 0;
			var size = level.Size;
			for (var x = 0; x < size.Width; x++)
			{
				for (var y = 0; y < size.Height; y++)
				{
					if (level.Blocks[x, y].Type != BlockType.None)
					{
						return blankYRows;
					}
				}

				blankYRows++;
			}
			
			throw new Exception("No blocks in level");
		}

		private static Vector3 CalculateExcessAtEnd(Data.Levels.Level level)
		{
			var y = CalculateExcessAtEndY(level);
			var x = CalculateExcessAtEndX(level);
			
			return new Vector3(x, 0, y);
		}

		private static float CalculateExcessAtEndY(Data.Levels.Level level)
		{
			var blankXRows = 0;
			var size = level.Size;
			for (var y = size.Height - 1; y >= 0; y--)
			{
				for (var x = size.Width - 1; x >= 0; x--)
				{
					if (level.Blocks[x, y].Type != BlockType.None)
					{
						return blankXRows;
					}
				}

				blankXRows++;
			}
			
			throw new Exception("No blocks in level");
		}

		private static float CalculateExcessAtEndX(Data.Levels.Level level)
		{
			var blankYRows = 0;
			var size = level.Size;
			for (var x = size.Width - 1; x >= 0; x--)
			{
				for (var y = size.Height - 1; y >= 0; y--)
				{
					if (level.Blocks[x, y].Type != BlockType.None)
					{
						return blankYRows;
					}
				}

				blankYRows++;
			}
			
			throw new Exception("No blocks in level");
		}
	}
}