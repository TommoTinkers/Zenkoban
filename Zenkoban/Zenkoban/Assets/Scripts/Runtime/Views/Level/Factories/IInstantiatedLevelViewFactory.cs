using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Views.Level.Instantiators;

namespace Zenkoban.Runtime.Views.Level.Factories
{
	public interface IInstantiatedLevelViewFactory
	{
		InstantiatedLevelView Construct(Data.Levels.Level level);
	}
}