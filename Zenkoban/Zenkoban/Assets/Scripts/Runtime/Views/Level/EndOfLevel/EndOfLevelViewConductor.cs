using DG.Tweening;
using Sirenix.Utilities;
using UnityEngine;
using Zenkoban.Extensions;
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
			var rng = new System.Random();
			
			objects.ForEach(o =>
			{

				var randomJumpPercent = (float) rng.NextDouble();
				var randomTimePercent = (float) rng.NextDouble() * 0.5f;
				
				var clip = o.transform.DOLocalJump(o.transform.position, GameSettings.BlockJumpPower.AddAPercentage(randomJumpPercent), GameSettings.BlockJumpCount, GameSettings.BlockJumpDuration.AddAPercentage(randomTimePercent));
				clip.SetDelay(randomTimePercent * 0.1f);
				clip.SetEase(Ease.Linear);
				clip.Play();
			});
		}
	}
}