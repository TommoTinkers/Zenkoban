using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;

namespace Zenkoban.Runtime.Extensions.Level
{
	public static class IceLevelExtensions
	{
		public static LevelPoint GetSlidePoint(this Data.Levels.Level level, LevelPoint point, MoveDirection direction)
		{
			var currentTile = level.TileAt(point).Type;
			if (currentTile == TileType.Ice && level.IsNone(point + direction))
			{
				return level.GetSlidePoint(point + direction, direction);
			}
			
			return point;
		}
	}
}