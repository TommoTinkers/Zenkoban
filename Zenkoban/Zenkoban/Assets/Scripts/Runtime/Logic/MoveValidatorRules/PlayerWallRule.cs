using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Extensions.Level;

namespace Zenkoban.Runtime.Logic.MoveValidatorRules
{
	public class PlayerWallRule : IPlayerMoveValidatorRule
	{
		public bool Validate(Level level, LevelPoint destination)
		{
			return !level.IsWall(destination);
		}
	}
}