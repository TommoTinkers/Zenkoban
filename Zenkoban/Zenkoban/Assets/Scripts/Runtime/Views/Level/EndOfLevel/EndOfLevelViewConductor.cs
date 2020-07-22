using DG.Tweening;
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

		public void MakeObjectsBounce()
		{
			var objects = FindObjectsOfType<ColorableGoalBlock>();
			objects.ForEach(o =>
			{
				var clip = o.transform.DOLocalJump(o.transform.position, 16f, 5, 2);
				clip.SetEase(Ease.Linear);
				clip.Play();
			});
		}
	}
}