using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;

namespace Zenkoban.Runtime.Logic.MoveValidatorRules
{
	internal class PlayerBlockRule : IPlayerMoveValidatorRule
	{
		public bool Validate(Level level, LevelPoint destination, MoveDirection direction)
		{
			if (level[destination].Type == BlockType.None)
			{
				return true;
			}
			
			return level[destination].Type == BlockType.Block && level[destination + direction ].Type == BlockType.None;
		}
	}
}