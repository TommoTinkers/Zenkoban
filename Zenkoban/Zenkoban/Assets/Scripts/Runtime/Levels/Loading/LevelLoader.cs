using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Data.Levels;

namespace Zenkoban.Runtime.Levels.Loading
{
	public class LevelLoader : ILevelLoader
	{
		private static readonly ITileGenerator tileGenerator = new TileGenerator();
		private static readonly IBlockGenerator blockGenerator = new BlockGenerator();
		
		public Level Load(ILevelAsset levelAsset)
		{
			var blocks = blockGenerator.Generate(levelAsset);
			var tiles = tileGenerator.Generate(levelAsset);
			
			return new Level(blocks, tiles, levelAsset.Size);
		}
	}
}