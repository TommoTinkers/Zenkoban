using UnityEngine;
using Zenkoban.Data.Levels;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.Views.Level
{
	public static class PositionGenerator
	{
		public static Vector3[,] GeneratePositions(LevelSize size)
		{
			var tileSize = GameSettings.TileSize;
			var tilePositions = new Vector3[size.Width, size.Height];

			var xPos = 0f;
			var yPos = 0f;
			
			for (var x = 0; x < size.Width; x++)
			{
				for (var y = 0; y < size.Height; y++)
				{
					tilePositions[x, y] = new Vector3(xPos, 0f, yPos);
					yPos += tileSize;
				}
				
				yPos = 0f;
				xPos += tileSize;
			}

			return tilePositions;
		}
	}
}