using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Runtime.Events;

namespace Zenkoban.Runtime.Audio
{
	[RequireComponent(typeof(AudioSource))]
	public abstract class EventSoundEffectManager<TEvent> : SerializedMonoBehaviour where TEvent : Enum
	{
		[SerializeField]
		private IEventPublisher<TEvent> eventPublisher = null;

		[SerializeField]
		private Dictionary<TEvent, AudioClip> audioClips = new Dictionary<TEvent, AudioClip>();

		private AudioSource audioSource;
		
		private void Awake()
		{
			eventPublisher.OnEventPublished += HandleEventPublished;
			audioSource = GetComponent<AudioSource>();
		}

		private void HandleEventPublished(TEvent @event)
		{
			if (audioClips.ContainsKey(@event))
			{
				audioSource.PlayOneShot(audioClips[@event]);	
			}
		}
	}
}