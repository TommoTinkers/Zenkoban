using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenkoban.Input.Movement;
using Zenkoban.Runtime.Flow.Levels.EndOfLevel;

namespace Zenkoban.Runtime.UI.EndOfLevel
{
	public class EndOfLevelMenu : SerializedMonoBehaviour
	{
		[SerializeField]
		private EndOfLevelMenuInputProvider inputProvider = null;

		[SerializeField]
		private CanvasGroup canvasGroup = null;
		
		public event Action<EndOfLevelChoice> OnUserChoose;
		
		public void Initialise()
		{
			canvasGroup.alpha = 0;
			canvasGroup.DOFade(1f, 0.4f).Play();
			inputProvider.OnContinue += CreateUserChoiceHandler(EndOfLevelChoice.Next);
			inputProvider.OnReplay += CreateUserChoiceHandler(EndOfLevelChoice.Repeat);
			inputProvider.OnHome += CreateUserChoiceHandler(EndOfLevelChoice.Home);
		}

		private Action CreateUserChoiceHandler(EndOfLevelChoice choice)
		{
			return () =>
			{
				var clip = canvasGroup.DOFade(0f, 0.4f).Play();
				clip.onComplete += () => OnUserChoose?.Invoke(choice);
				clip.Play();
			};
		}
	}
}