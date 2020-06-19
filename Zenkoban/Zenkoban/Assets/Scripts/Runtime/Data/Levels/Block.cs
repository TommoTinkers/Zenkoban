using System;

namespace Zenkoban.Runtime.Data.Levels
{
	public class Block
	{
		public Guid Id { get; }
		public BlockType Type { get; }

		public Block(BlockType type)
		{
			Type = type;
			Id = Guid.NewGuid();
		}
	}
}