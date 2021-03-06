using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Extensions.Level;

namespace Zenkoban.Runtime.Logic.MoveValidatorRules
{
	public class PlayerWallRule : IPlayerMoveValidatorRule
	{
		public bool Validate(Level level, LevelPoint destination, MoveDirection direction)
		{
			return !level.IsWall(destination);
		}
	}
}