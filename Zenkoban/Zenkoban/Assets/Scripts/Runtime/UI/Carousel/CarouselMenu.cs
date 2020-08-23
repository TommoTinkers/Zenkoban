using System;
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
			
			ChangeNonFocusedPanels(selectedIndex, float.Epsilon);
		}

		
		[Button("CycleRight")]
		public void CycleRight() => CycleTo(selectedIndex + 1, GameSettings.CarouselDuration);

		[Button("CycleLeft")]
		public void CycleLeft() => CycleTo(selectedIndex - 1, GameSettings.CarouselDuration);

		[Button("Right 5")]
		public void CycleRightFive()
		{
			var targetIndex = panels.ThisIndexOrMax(selectedIndex + 5);
			CycleTo(targetIndex, GameSettings.CarouselDuration * 2.5f);
		}

		[Button("Left 5")]
		public void CycleLeftFive()
		{
			var targetIndex = panels.ThisIndexOrMin(selectedIndex - 5);
			CycleTo(targetIndex, GameSettings.CarouselDuration * 2.5f);
		}

		private static void Scale(Transform panel, float scaleMultiplier, float duration)
		{
			panel.DOScale(Vector3.one * scaleMultiplier, duration).Play();
		}

		private void CycleTo(int index, float totalDuration)
		{
			if (!panels.IsValidIndex(index) || isTransitioning)
			{
				return;
			}
			
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
			
			Scale(panelToEnlarge, 1, totalDuration);
			
			panelToEnlarge.GetComponent<CanvasGroup>().DOFade(1f, totalDuration).Play();
			
			ChangeNonFocusedPanels(index, totalDuration);
			
			anim.Play();
		}

		private void HandleTransitionComplete()
		{
			isTransitioning = false;
		}

		private float GetAlphaBasedOnDistance(int distance) => alphasBasedOnDistance.ContainsKey(distance) ? alphasBasedOnDistance[distance] : 0f;

		private float GetScaleBasedOnDistance(int distance)
		{
			CreateScalesDistanceTable();
			return scalesBasedOnDistance.ContainsKey(distance) ? scalesBasedOnDistance[distance] : 0f;
		}

		private void CreateScalesDistanceTable()
		{
			scalesBasedOnDistance = scalesBasedOnDistance ?? new Dictionary<int, float>
			{
				{0, 1f},
				{1, nonFocusScale},
				{2, nonFocusScale * nonFocusScale},
			};
		}

		private Dictionary<int, float> scalesBasedOnDistance;
		private readonly Dictionary<int, float> alphasBasedOnDistance = new Dictionary<int, float>
		{
			{0, 1f},
			{1, 0.8f},
			{2, 0.5f},
		};
		
		
		private void ChangeNonFocusedPanels(int index, float totalDuration)
		{
			for (var x = 0; x < panels.Count; x++)
			{
				var dist = Math.Abs(index - x);
				
				FadePanel(x, dist, totalDuration);
				ScalePanel(x, dist, totalDuration);
			}
		}

		private void ScalePanel(int index, int distance, float totalDuration)
		{
			var scaleFactor = GetScaleBasedOnDistance(distance);	
			Scale(panels[index], scaleFactor, totalDuration);
		}

		private void FadePanel(int index, int distance, float totalDuration)
		{
			var opacityScaleFactor = GetAlphaBasedOnDistance(distance);
				
			panels[index].GetComponent<CanvasGroup>().DOFade(opacityScaleFactor, totalDuration).Play();
		}
	}
}
