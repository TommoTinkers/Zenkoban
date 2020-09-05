using Sirenix.OdinInspector;
using UnityEngine;

namespace Zenkoban.Runtime.UI.LinearMenu
{
	public class LinearMenu : SerializedMonoBehaviour
	{
		[SerializeField] private ILinearMenuButton[] buttons = null;

		private void Awake()
		{
			buttons = buttons ?? null;
		}
	}
}