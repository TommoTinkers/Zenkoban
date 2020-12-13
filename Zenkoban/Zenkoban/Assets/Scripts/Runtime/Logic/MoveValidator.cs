using System.Collections.Generic;
using System.Linq;
using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Logic.MoveValidatorRules;

namespace Zenkoban.Runtime.Logic
{
	public class MoveValidator
	{
		private readonly Level level;
		
		private readonly List<IPlayerMoveValidatorRule> PlayerMoveValidatorRules = new List<IPlayerMoveValidatorRule>
		{
			new PlayerWallRule(),
			new PlayerBlockRule(BlockType.Block),
			new PlayerBlockRule(BlockType.MirrorBlock)
		};
		
		public MoveValidator(Level level)
		{
			this.level = level;
		}

		public bool Validate(LevelPoint playerPos, MoveDirection direction)
		{
			var playerDest = playerPos + direction;
			
			if (PlayerMoveValidatorRules.Any(r => r.Validate(level, playerDest, direction) == false))
			{
				return false;
			}

			return true;
		}
	}
}