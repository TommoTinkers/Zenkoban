using Zenkoban.Data.Levels;

namespace Zenkoban.Assets.Levels
{
	public interface ILevelAsset
	{
		TileType[,] Tiles { get; }
		LevelSize Size { get; }
	}
}