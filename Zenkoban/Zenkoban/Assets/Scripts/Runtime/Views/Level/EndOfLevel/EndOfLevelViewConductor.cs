using Sirenix.Utilities;
using UnityEngine;
using Zenkoban.Runtime.Views.Level.Objects;

namespace Zenkoban.Runtime.Views.Level.EndOfLevel
{
	public class EndOfLevelViewConductor : MonoBehaviour
	{
		public void TurnBlocksGreen()
		{
			var objects = FindObjectsOfType<ColorableGoalBlock>();
			objects.ForEach(o => o.ColorToCelebration());
		}
	}
}