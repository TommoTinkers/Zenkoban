using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Runtime.Flow.Levels.EndOfLevel;

namespace Zenkoban.Runtime.UI.EndOfLevel
{
	public class EndOfLevelMenuOrchestrator : SerializedMonoBehaviour, IEndOfLevelChoiceProvider
	{
		[SerializeField]
		private EndOfLevelMenu prefab = null;
		
		public void GetChoice(Action<EndOfLevelChoice> onUserMakingChoice)
		{
			var menu = Instantiate(prefab);

			Action<EndOfLevelChoice> onChoose = c =>
			{
				Destroy(menu.gameObject);
				onUserMakingChoice?.Invoke(c);
			};

			menu.OnUserChoose += onChoose;
			menu.Initialise();
		}
	}
}