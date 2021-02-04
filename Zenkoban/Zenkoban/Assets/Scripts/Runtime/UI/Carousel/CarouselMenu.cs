using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Extensions.Utility.Collections;
using Zenkoban.Input.Movement;
using Zenkoban.Runtime.UI.Core;
using Zenkoban.Settings;
using Zenkoban.Utils.Combinators;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class CarouselMenu : SerializedMonoBehaviour
	{
		public event Action<ICarouselPanel, int> OnItemSelected;
		public event Action OnUserChoseBack;

		[SerializeField]
		private Transform panelContainer = null;

		[SerializeField]
		private float panelSpacing = 8f;

		[SerializeField]
		private float nonFocusScale = 0.6f;
		
		[SerializeField] private ICarouselInputProvider inputProvider = null;

		private List<ICarouselPanel> panels;
		private int selectedIndex;
		private bool isTransitioning;
		private bool menuEnabled = true;

		public void Enable() => menuEnabled = true;
		public void Disable() => menuEnabled = false;
		
		private void Start()
		{
			var IfMenuEnabledThen = Combinators.IfThen(() => menuEnabled);

			inputProvider.OnCycleLeft += IfMenuEnabledThen(CycleLeft);
			inputProvider.OnCycleRight += IfMenuEnabledThen(CycleRight);
			inputProvider.OnSelect += IfMenuEnabledThen(HandleSelection);
			inputProvider.OnBack += IfMenuEnabledThen(HandleUserGoingBack);
		}


		private void HandleUserGoingBack()
		{
			OnUserChoseBack?.Invoke();
		}

		private void HandleSelection()
		{
			OnItemSelected?.Invoke(panels[selectedIndex], selectedIndex); 
		}

		public void Initialize(IEnumerable<ICarouselPanel> newPanels, int index = 0)
		{
			panels = new List<ICarouselPanel>();
			
			var runningSpacing = 0f;
			foreach (var panel in newPanels)
			{
				panel.transform.localPosition = panelContainer.localPosition + Vector3.right * runningSpacing;
				
				panel.transform.localScale = Vector3.one * nonFocusScale;
				panel.transform.SetParent(panelContainer, true);
				panels.Add(panel);
				
				runningSpacing += panelSpacing;
			}

			
			panels[index].transform.localScale = Vector3.one;
			
			ChangeNonFocusedPanels(index, float.Epsilon);
			CycleTo(index, 0.1f);
			HandleEnablingAndDisablingOfPanels();
		}


		[Button("CycleRight")]
		public void CycleRight() => CycleTo(selectedIndex + 1, GameSettings.CarouselDuration);

		[Button("CycleLeft")]
		public void CycleLeft() => CycleTo(selectedIndex - 1, GameSettings.CarouselDuration);

		
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
			
			var panelToEnlarge = panels[index].transform;

			var numberOfPanelsToScroll = selectedIndex - index;

			var newContainerPosition = panelContainer.localPosition + Vector3.right * (numberOfPanelsToScroll * panelSpacing);
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
			HandleEnablingAndDisablingOfPanels();
		}

		private void HandleEnablingAndDisablingOfPanels()
		{
			panels[selectedIndex].Enable();
			foreach (var panel in panels.Except(new[] {panels[selectedIndex]}))
			{
				panel.Disable();
			}
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
				panels[x].Canvas.sortingOrder = panels.Count() - dist;
			}
		}

		private void ScalePanel(int index, int distance, float totalDuration)
		{
			var scaleFactor = GetScaleBasedOnDistance(distance);	
			Scale(panels[index].transform, scaleFactor, totalDuration);
		}

		private void FadePanel(int index, int distance, float totalDuration)
		{
			var opacityScaleFactor = GetAlphaBasedOnDistance(distance);
				
			panels[index].transform.GetComponent<CanvasGroup>().DOFade(opacityScaleFactor, totalDuration).Play();
		}
	}
}
