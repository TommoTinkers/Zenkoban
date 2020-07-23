using System;

namespace Zenkoban.Runtime.Events
{
	public interface IEventDispatcher<TEvent> where TEvent : Enum
	{
		void Publish(TEvent eventType);
	}
}