using UnityEngine;

namespace Zenkoban.Runtime.Views.Level.Instantiators
{
	public static class LevelInstantiator
	{
		public static void InstantiateLevel(Data.Levels.Level level, ILevelTheme levelTheme, Transform parent)
		{
			var size = level.Size;
			var positions = PositionGenerator.GeneratePositions(size);

			for (var x = 0; x < size.Width; x++)
			{
				for (var y = 0; y < size.Height; y++)
				{
					
				}
			}
		}
	}
}