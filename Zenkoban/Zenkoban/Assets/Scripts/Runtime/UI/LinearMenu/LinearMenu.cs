using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Input.Movement;
using Zenkoban.Utils;

namespace Zenkoban.Runtime.UI.LinearMenu
{
	public class LinearMenu : SerializedMonoBehaviour
	{
		[SerializeField] private ILinearMenuButton[] buttons = null;
		[SerializeField] private ILinearMenuInputProvider inputProvider = null;

		private IndexCycler currentButtonIndex;
		
		private void Awake()
		{
			buttons = buttons ?? null;

			inputProvider.OnUp += MoveUp;
			inputProvider.OnDown += MoveDown;
			inputProvider.OnSelect += HandleSelect;
			
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
	}
}