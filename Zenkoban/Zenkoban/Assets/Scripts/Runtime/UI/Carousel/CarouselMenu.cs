using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
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

		[Button("CycleLeft")]
		public void CycleLeft()
		{
			if (selectedIndex < panels.Count - 1 && !isTransitioning)
			{
				var anim = panelContainer.DOLocalMove(panelContainer.transform.position + (Vector3.left * panelSpacing), GameSettings.CarouselDuration);
				anim.onComplete += (() => 
						{
							selectedIndex++;
							HandleTransitionComplete();
						});

				
				isTransitioning = true;

				panels[selectedIndex].DOScale(Vector3.one * nonFocusScale, GameSettings.CarouselDuration).Play();

				if ((selectedIndex + 1) <= panels.Count - 1)
				{
					panels[selectedIndex + 1].DOScale(Vector3.one, GameSettings.CarouselDuration).Play();
				}
				
				anim.Play();
				

			}
		}
		
		[Button("CycleRight")]
		public void CycleRight()
		{
			if (selectedIndex > 0 && !isTransitioning)
			{
				var anim = panelContainer.DOLocalMove(panelContainer.transform.position + (Vector3.right * panelSpacing), GameSettings.CarouselDuration);
				anim.onComplete += (() => 
				{
					selectedIndex--;
					HandleTransitionComplete();
				});

				panels[selectedIndex].DOScale(Vector3.one * nonFocusScale, GameSettings.CarouselDuration).Play();

				if ((selectedIndex - 1) >= 0)
				{
					panels[selectedIndex - 1].DOScale(Vector3.one, GameSettings.CarouselDuration).Play();
				}

				
				isTransitioning = true;
				anim.Play();
			}
		}
		
		private void HandleTransitionComplete()
		{
			isTransitioning = false;
		}
	}
}
