using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Zenkoban.Runtime.Views.Level.Movement
{
	public class BlockMovementAction
	{
		private readonly List<TweenerCore<Vector3, Vector3, VectorOptions>> tweens = new List<TweenerCore<Vector3, Vector3, VectorOptions>>();
		private int completedTweens;
		private bool hasStarted;
		private Action callback;
		
		public void Add(TweenerCore<Vector3, Vector3, VectorOptions> tween)
		{
			if (hasStarted)
			{
				throw new Exception("Block Movement Action cannot be added to once started");
			}
			
			tween.onComplete += OnSingleTweenCompleted;
			tweens.Add(tween);
		}

		private void OnSingleTweenCompleted()
		{
			completedTweens++;
			if (completedTweens == tweens.Count)
			{
				callback?.Invoke();
			}
		}

		public void Start(Action callack)
		{
			if (hasStarted)
			{
				throw new Exception("Block Movement Action cannot be started more than once.");
			}
			tweens.ForEach(t => t.Play());
			hasStarted = true;
			callback = callack;
		}
	}
}