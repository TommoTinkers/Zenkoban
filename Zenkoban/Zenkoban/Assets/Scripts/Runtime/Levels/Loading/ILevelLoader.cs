using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Data.Levels;

namespace Zenkoban.Runtime.Levels.Loading
{
	public interface ILevelLoader
	{
		Level Load(ILevelAsset levelAsset);
	}
}