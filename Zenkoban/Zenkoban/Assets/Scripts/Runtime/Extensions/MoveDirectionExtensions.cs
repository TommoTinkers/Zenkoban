using System;
using Zenkoban.Runtime.Data.Movement;

namespace Zenkoban.Runtime.Extensions
{
	public static class MoveDirectionExtensions
	{
		public static MoveDirection Invert(this MoveDirection direction)
		{
			switch(direction)
			{
				case MoveDirection.Up:
					return MoveDirection.Down;
				case MoveDirection.Down:
					return MoveDirection.Up;
				case MoveDirection.Left:
					return MoveDirection.Right;
				case MoveDirection.Right:
					return MoveDirection.Left;
				default:
					throw new ArgumentOutOfRangeException(nameof(direction), direction, "This error should never happen.");
			}
		}
	}
}