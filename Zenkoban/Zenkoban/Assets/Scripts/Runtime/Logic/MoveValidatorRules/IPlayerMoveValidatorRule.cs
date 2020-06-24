using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;

namespace Zenkoban.Runtime.Logic.MoveValidatorRules
{
	public interface IPlayerMoveValidatorRule
	{
		bool Validate(Level level, LevelPoint destination);
	}
}