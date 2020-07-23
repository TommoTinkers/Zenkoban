using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zenkoban.Runtime.Events
{
	public class EventSystem<TEvent> : MonoBehaviour, IEventDispatcher<TEvent>, IEventPublisher<TEvent> where TEvent : System.Enum
	{
		private readonly Dictionary<TEvent, List<Action>> listeners = new Dictionary<TEvent, List<Action>>();

		public event Action<TEvent> OnEventPublished;
			
		public void AddListener(TEvent eventType, Action action)
		{
			EnsureEventTypeIsInDictionary(eventType);
			
			listeners[eventType].Add(action);
		}

		public void Publish(TEvent eventType)
		{
			EnsureEventTypeIsInDictionary(eventType);
			
			listeners[eventType].ForEach(Dispatch);
			
			OnEventPublished?.Invoke(eventType);
		}

		private static void Dispatch(Action eventListener)
		{
			eventListener?.Invoke();
		}

		private void EnsureEventTypeIsInDictionary(TEvent eventType)
		{
			if (!listeners.ContainsKey(eventType))
			{
				listeners[eventType] = new List<Action>();
			}
		}
	}
}