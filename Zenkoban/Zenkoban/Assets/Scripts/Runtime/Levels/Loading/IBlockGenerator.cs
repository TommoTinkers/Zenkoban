using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Data.Levels;

namespace Zenkoban.Runtime.Levels.Loading
{
	public interface IBlockGenerator
	{
		Block[,] Generate(ILevelAsset level);
	}
}