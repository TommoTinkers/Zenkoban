using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zenkoban.Runtime.Events
{
	public class EventSystem<TEvent> : MonoBehaviour, IEventDispatcher<TEvent> where TEvent : System.Enum
	{
		private readonly Dictionary<TEvent, List<Action>> _listeners = new Dictionary<TEvent, List<Action>>();

		public void AddListener(TEvent eventType, Action action)
		{
			EnsureEventTypeIsInDictionary(eventType);
			
			_listeners[eventType].Add(action);
		}

		public void Publish(TEvent eventType)
		{
			EnsureEventTypeIsInDictionary(eventType);
			
			_listeners[eventType].ForEach(Dispatch);
		}

		private static void Dispatch(Action eventListener)
		{
			eventListener?.Invoke();
		}

		private void EnsureEventTypeIsInDictionary(TEvent eventType)
		{
			if (!_listeners.ContainsKey(eventType))
			{
				_listeners[eventType] = new List<Action>();
			}
		}
	}
}