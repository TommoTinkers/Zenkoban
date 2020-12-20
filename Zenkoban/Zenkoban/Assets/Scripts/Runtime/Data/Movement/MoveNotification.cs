using System;
using Zenkoban.Data.Levels;

namespace Zenkoban.Runtime.Data.Movement
{
	public class MoveNotification
	{
		public LevelPoint Delta { get; }
		public Guid Id { get; }

		
		public MoveNotification(Guid id, LevelPoint delta)
		{
			Delta = delta;
			Id = id;
		}
	}
}