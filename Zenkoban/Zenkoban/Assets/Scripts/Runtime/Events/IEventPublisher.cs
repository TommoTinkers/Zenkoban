using System;

namespace Zenkoban.Runtime.Events
{
	public interface IEventPublisher<TEvent> where TEvent : Enum
	{
		event Action<TEvent> OnEventPublished;
		void AddListener(TEvent eventType, Action action);
	}
}