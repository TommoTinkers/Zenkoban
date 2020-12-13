using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;

namespace Zenkoban.Runtime.Logic.MoveValidatorRules
{
	internal class PlayerBlockRule : IPlayerMoveValidatorRule
	{
		private readonly BlockType blockType;

		public PlayerBlockRule(BlockType blockType)
		{
			this.blockType = blockType;
		}

		public bool Validate(Level level, LevelPoint destination, MoveDirection direction)
		{
			if (level[destination].Type != blockType)
			{
				return true;
			}
			
			return level[destination].Type == blockType && level[destination + direction ].Type == BlockType.None;
		}
	}
}