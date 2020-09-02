using System;
using System.Collections.Generic;
using UnityEngine;
using Zenkoban.Extensions.Utility.Collections;
using Zenkoban.Runtime.UI.Core;
using Object = UnityEngine.Object;

namespace Zenkoban.Runtime.UI.Carousel
{
	public interface ICarouselTweeningStrategy
	{
		void Out(CarouselMenu menu, Action<CarouselMenu> callback);
		void In(CarouselMenu menu, Action<CarouselMenu> callback);
	}
	
	public class CompoundCarouselMenu
	{
		private readonly IList<Func<int, CarouselMenu>> carouselMenuCreators;
		private readonly ICarouselTweeningStrategy tweener;

		private CarouselMenu currentCarouselMenu;
		
		private int currentMenuIndex = 0;
		
		public CompoundCarouselMenu(IList<Func<int, CarouselMenu>> carouselMenuCreators, ICarouselTweeningStrategy tweener, int rootMenuStartIndex = 0)
		{
			this.carouselMenuCreators = carouselMenuCreators;
			this.tweener = tweener;
			currentCarouselMenu = carouselMenuCreators[currentMenuIndex]?.Invoke(rootMenuStartIndex);
			currentCarouselMenu.OnItemSelected += HandleCarouselItemSelected;
			tweener.In(currentCarouselMenu, c => c.Enable());
		}

		private void HandleCarouselItemSelected(ICarouselPanel panel, int selectedIndex)
		{
			if (carouselMenuCreators.IsNotLast(currentMenuIndex))
			{
				KillMenu(currentCarouselMenu);
				currentMenuIndex++;
				ShowSubMenu(selectedIndex);
			}

			if (carouselMenuCreators.IsLast(currentMenuIndex))
			{
				//This means the user has selected an item. Invoke the item chosen event.
				//Tween out the current menu ?? 
			}
		}

		private void ShowSubMenu(int selectedIndex)
		{
			currentCarouselMenu = carouselMenuCreators[currentMenuIndex]?.Invoke(selectedIndex);
			currentCarouselMenu.OnItemSelected += HandleCarouselItemSelected;
			tweener.In(currentCarouselMenu, c => c.Enable());
		}

		private void KillMenu(CarouselMenu menu)
		{
			menu.Disable();
			//Tween out the menu
			tweener.Out(menu, m => Object.Destroy(menu.gameObject));
			//Destroy the menu after tween is complete.
		}
	}
}