using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Input.Movement;
using Zenkoban.Runtime.Common.Mediators;
using Zenkoban.Utils;
using Zenkoban.Utils.Combinators;

namespace Zenkoban.Runtime.UI.LinearMenu
{
	public class LinearMenu : SerializedMonoBehaviour, IActivatable
	{
		[SerializeField] private ILinearMenuButton[] buttons = null;
		[SerializeField] private ILinearMenuInputProvider inputProvider = null;

		[SerializeField]
		private CanvasGroup canvasGroup = null;
		
		private IndexCycler currentButtonIndex;
		private bool isActive = true;

		private void Awake()
		{
			var ProcessInputIfActive = Combinators.If(() => isActive);
			
			inputProvider.OnUp += ProcessInputIfActive(MoveUp);
			inputProvider.OnDown += ProcessInputIfActive(MoveDown);
			inputProvider.OnSelect += ProcessInputIfActive(HandleSelect);
			
			currentButtonIndex = new IndexCycler(buttons, 0);
			Refresh();
		}

		private void HandleSelect()
		{
			buttons[currentButtonIndex].Select();
		}

		private void MoveDown()
		{
			currentButtonIndex.Inc();
			Refresh();
		}

		private void MoveUp()
		{
			currentButtonIndex.Dec();
			Refresh();
		}

		private void Refresh()
		{
			for (var index = 0; index < buttons.Length; index++)
			{
				buttons[index].UnHighlight();
			}
			
			buttons[currentButtonIndex].Highlight();
		}

		public void SetActive()
		{
			var anim = canvasGroup.DOFade(1f, 1f);
			anim.onComplete += () => isActive = true;
			anim.Play();
		}

		public void SetInactive()
		{
			var anim = canvasGroup.DOFade(0f, 1f);
			isActive = false;
			anim.Play();
		}
	}
}