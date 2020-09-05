using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Zenkoban.Runtime.UI.LinearMenu
{
	public class LinearMenuButton : SerializedMonoBehaviour, ILinearMenuButton
	{
		[SerializeField] private UnityAction OnSelected = null;

		[SerializeField]
		private GameObject highlightedDisplay = null;
		
		[SerializeField]
		private GameObject unHighlightedDisplay = null;

		private bool isHighlighted;
		
		public void Highlight() => SetIsHighlighted(true);
		public void UnHighlight() => SetIsHighlighted(false);
		
		private void SetIsHighlighted(bool highlighted)
		{
			isHighlighted = highlighted;
			highlightedDisplay.SetActive(highlighted);
			unHighlightedDisplay.SetActive(!highlighted);
		}

		public void Select()
		{
			OnSelected?.Invoke();
		}
	}
}