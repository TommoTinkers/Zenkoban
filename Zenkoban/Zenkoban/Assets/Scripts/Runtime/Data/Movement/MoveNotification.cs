using System;

namespace Zenkoban.Runtime.Data.Movement
{
	public class MoveNotification
	{
		public Guid Id { get; }

		public MoveDirection Direction { get; }

		public MoveNotification(Guid id, MoveDirection direction)
		{
			Id = id;
			Direction = direction;
		}
	}
}