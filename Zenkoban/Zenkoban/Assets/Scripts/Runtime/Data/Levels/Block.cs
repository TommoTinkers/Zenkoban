using System;

namespace Zenkoban.Runtime.Data.Levels
{
	public class Block : IEquatable<Block>
	{
		public Guid Id { get; }
		public BlockType Type { get; }
		
		public Block(BlockType type)
		{
			Type = type;
			Id = Guid.NewGuid();
		}

		public bool Equals(Block other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Id.Equals(other.Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Block) obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public static bool operator ==(Block left, Block right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Block left, Block right)
		{
			return !Equals(left, right);
		}
	}
}