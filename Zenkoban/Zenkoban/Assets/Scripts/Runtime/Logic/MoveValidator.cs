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
		private readonly IReadOnlyDictionary<MoveDirection, LevelPoint> offsets;

		private readonly List<IPlayerMoveValidatorRule> PlayerMoveValidatorRules = new List<IPlayerMoveValidatorRule>
		{
			new PlayerWallRule()
		};
		
		public MoveValidator(Level level, IReadOnlyDictionary<MoveDirection, LevelPoint> offsets)
		{
			this.level = level;
			this.offsets = offsets;
		}

		public bool Validate(LevelPoint playerPos, MoveDirection direction)
		{
			var playerDest = playerPos + offsets[direction];
			
			if (PlayerMoveValidatorRules.Any(r => r.Validate(level, playerDest) == false))
			{
				return false;
			}

			return true;
		}
		
		
	}
}