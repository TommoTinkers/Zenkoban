using System.Collections.Generic;
using Zenkoban.Runtime.Data.Levels;

namespace Zenkoban.Runtime.Extensions.Blocks
{
	public static class BlockExtensions
	{
		private static readonly HashSet<BlockType> PushableBlockTypes = new HashSet<BlockType>
		{
			BlockType.Block, BlockType.MirrorBlock
		};
		
		public static bool IsPushable(this Data.Levels.Block block) => (PushableBlockTypes.Contains(block.Type));
	}
}