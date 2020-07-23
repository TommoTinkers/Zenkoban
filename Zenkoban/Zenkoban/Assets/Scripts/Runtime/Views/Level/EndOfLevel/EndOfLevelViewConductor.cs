using DG.Tweening;
using Sirenix.Utilities;
using UnityEngine;
using Zenkoban.Runtime.Events.InGameEvents;
using Zenkoban.Runtime.Views.Level.Objects;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.Views.Level.EndOfLevel
{
	public class EndOfLevelViewConductor : MonoBehaviour
	{
		public void PlayCelebrationTune()
		{
			FindObjectOfType<InGameEventSystem>().Publish(InGameEvent.LevelCompleted);
		}
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
				var clip = o.transform.DOLocalJump(o.transform.position, GameSettings.BlockJumpPower, GameSettings.BlockJumpCount, GameSettings.BlockJumpDuration);
				clip.SetEase(Ease.Linear);
				clip.Play();
			});
		}
	}
}