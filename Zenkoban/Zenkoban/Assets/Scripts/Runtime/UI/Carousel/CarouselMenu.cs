using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Extensions.Utility.Collections;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class CarouselMenu : MonoBehaviour
	{
		[SerializeField]
		private Transform panelContainer = null;

		[SerializeField]
		private float panelSpacing = 8f;

		[SerializeField]
		private float nonFocusScale = 0.6f;
		
		private List<Transform> panels;
		private int selectedIndex;
		private bool isTransitioning;

		public void Initialize(IEnumerable<GameObject> newPanels)
		{
			panels = new List<Transform>();
			
			var runningSpacing = 0f;
			foreach (var panel in newPanels)
			{
				panel.transform.position = panelContainer.position + Vector3.right * runningSpacing;
				panel.transform.SetParent(panelContainer, true);

				panel.transform.localScale = Vector3.one * nonFocusScale;
				
				panels.Add(panel.transform);
				
				runningSpacing += panelSpacing;
			}

			selectedIndex = 0;
			panels[selectedIndex].localScale = Vector3.one;
		}

		private void CycleTo(int index, float totalDuration)
		{
			if (!panels.IsValidIndex(index) || isTransitioning)
			{
				return;
			}

			var panelToShrink = panels[selectedIndex];
			var panelToEnlarge = panels[index];

			var numberOfPanelsToScroll = selectedIndex - index;

			var newContainerPosition = panelContainer.position + Vector3.right * (numberOfPanelsToScroll * panelSpacing);
			var anim = panelContainer.DOLocalMove(newContainerPosition, totalDuration);
			
			anim.onComplete += () =>
			{
				selectedIndex = index;
				HandleTransitionComplete();
			};

			isTransitioning = true;
			
			ScaleDown(panelToShrink, totalDuration);
			ScaleUp(panelToEnlarge, totalDuration);

			anim.Play();
		}

		[Button("CycleRight")]
		public void CycleRight() => CycleTo(selectedIndex + 1, GameSettings.CarouselDuration);
		
		[Button("CycleLeft")]
		public void CycleLeft() => CycleTo(selectedIndex - 1, GameSettings.CarouselDuration);

		[Button("Right 5")]
		public void CycleRightFive()
		{
			var targetIndex = panels.ThisIndexOrMax(selectedIndex + 5);
			CycleTo(targetIndex, GameSettings.CarouselDuration);
		}
		
		[Button("Left 5")]
		public void CycleLeftFive()
		{
			var targetIndex = panels.ThisIndexOrMin(selectedIndex - 5);
			CycleTo(targetIndex, GameSettings.CarouselDuration);
		}
		
		private void ScaleDown(Transform panel, float duration) => Scale(panel, nonFocusScale, duration);
		private static void ScaleUp(Transform panel, float duration) => Scale(panel, 1f, duration);

		private static void Scale(Transform panel, float scaleMultiplier, float duration)
		{
			panel.DOScale(Vector3.one * scaleMultiplier, duration).Play();
		}
		
		private void HandleTransitionComplete()
		{
			isTransitioning = false;
		}
	}
}
