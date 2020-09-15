using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenkoban.Extensions.Utility.Collections;
using Zenkoban.Runtime.Flow;
using Zenkoban.Runtime.UI.Carousel.Movement;
using Zenkoban.Runtime.UI.Core;
using Zenkoban.Settings;
using Object = UnityEngine.Object;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class CompoundCarouselMenu
	{
		public event Action<int[]> OnItemSelected;
		private readonly IList<Func<int, CarouselMenu>> carouselMenuCreators;
		private readonly ICarouselTweeningStrategy tweener;
		private readonly Stack<int> previousSelectedIndices = new Stack<int>();
		
		private CarouselMenu currentCarouselMenu;
		
		private int currentMenuIndex = 0;
		
		public CompoundCarouselMenu(IList<Func<int, CarouselMenu>> carouselMenuCreators, ICarouselTweeningStrategy tweener, int rootMenuStartIndex = 0)
		{
			this.carouselMenuCreators = carouselMenuCreators;
			this.tweener = tweener;
			currentCarouselMenu = carouselMenuCreators[currentMenuIndex]?.Invoke(rootMenuStartIndex);
			currentCarouselMenu.OnItemSelected += HandleCarouselItemSelected;
			currentCarouselMenu.OnUserChoseBack += HandleBackSelected;
			tweener.In(currentCarouselMenu, c => c.Enable());
		}

		private void HandleCarouselItemSelected(ICarouselPanel panel, int selectedIndex)
		{
			currentCarouselMenu.Disable();
			if (carouselMenuCreators.IsNotLast(currentMenuIndex))
			{
				previousSelectedIndices.Push(selectedIndex);
				KillMenu(currentCarouselMenu);
				currentMenuIndex++;
				ShowSubMenu(selectedIndex);
			}

			else if (carouselMenuCreators.IsLast(currentMenuIndex))
			{
				
				tweener.Out(currentCarouselMenu, c =>
				{
					var indices = previousSelectedIndices.Concat(new[] {selectedIndex}).ToArray();
					OnItemSelected?.Invoke(indices);
				});

			}
		}

		private void HandleBackSelected()
		{
			if (carouselMenuCreators.IsNotFirst(currentMenuIndex))
			{
				var returnSelectedIndex = previousSelectedIndices.Pop();
				KillMenu(currentCarouselMenu);
				currentMenuIndex--;
				ShowSubMenu(returnSelectedIndex);
			}
			else
			{
				KillMenu(currentCarouselMenu, m => SceneFlow.LoadMainMenu());
			}
		}
		
		private void ShowSubMenu(int selectedIndex)
		{
			currentCarouselMenu = carouselMenuCreators[currentMenuIndex]?.Invoke(selectedIndex);
			currentCarouselMenu.Disable();
			currentCarouselMenu.OnItemSelected += HandleCarouselItemSelected;
			currentCarouselMenu.OnUserChoseBack += HandleBackSelected;
			tweener.In(currentCarouselMenu, c => c.Enable());
		}
		

		private void KillMenu(CarouselMenu menu, Action<CarouselMenu> callback = null)
		{
			menu.Disable();
			tweener.Out(menu, callback);
			tweener.Out(menu, m =>
			{
				callback?.Invoke(m);
				Object.Destroy(menu.gameObject);
			});
		}
	}
}