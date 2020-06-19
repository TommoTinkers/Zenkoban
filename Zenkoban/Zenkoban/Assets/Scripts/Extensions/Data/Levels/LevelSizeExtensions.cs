using Zenkoban.Data.Levels;

namespace Zenkoban.Extensions.Data.Levels
{
	public static class LevelSizeExtensions
	{
		public static int Area(this LevelSize size) => size.Width * size.Height;
	}
}