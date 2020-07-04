using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;

namespace Zenkoban.Runtime.Logic.MoveValidatorRules
{
	public interface IPlayerMoveValidatorRule
	{
		bool Validate(Level level, LevelPoint destination, MoveDirection direction);
	}
}