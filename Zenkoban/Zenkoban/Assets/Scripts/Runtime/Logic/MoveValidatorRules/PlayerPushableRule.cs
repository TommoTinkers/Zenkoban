using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Extensions.Blocks;

namespace Zenkoban.Runtime.Logic.MoveValidatorRules
{
	internal class PlayerPushableRule : IPlayerMoveValidatorRule
	{
		public bool Validate(Level level, LevelPoint destination, MoveDirection direction)
		{
			if (!level[destination].IsPushable())
			{
				return true;
			}
			
			return level[destination + direction ].Type == BlockType.None;
		}
	}
}