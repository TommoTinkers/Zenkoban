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
		void Out(CarouselMenu menu, Action<CarouselMenu> action);
	}
	
	public class CompoundCarouselMenu
	{
		private readonly IList<Func<int, CarouselMenu>> carouselMenuCreators;
		private readonly ICarouselTweeningStrategy tweener;

		private CarouselMenu currentCarouselMenu;
		
		private int currentIndex = 0;
		
		public CompoundCarouselMenu(IList<Func<int, CarouselMenu>> carouselMenuCreators, ICarouselTweeningStrategy tweener, int rootMenuStartIndex = 0)
		{
			this.carouselMenuCreators = carouselMenuCreators;
			this.tweener = tweener;
			currentCarouselMenu = carouselMenuCreators[0]?.Invoke(rootMenuStartIndex);
			currentCarouselMenu.OnItemSelected += HandleCarouselItemSelected;
		}

		private void HandleCarouselItemSelected(ICarouselPanel panel, int index)
		{
			if (carouselMenuCreators.IsNotLast(currentIndex))
			{
				KillMenu(currentCarouselMenu);
				//Bring in the new menu.	
			}

			if (carouselMenuCreators.IsLast(currentIndex))
			{
				//This means the user has selected an item. Invoke the item chosen event.
				//Tween out the current menu ?? 
			}
			
		}

		private void KillMenu(CarouselMenu menu)
		{
			menu.Disable();
			//Tween out the menu
			tweener.Out(menu, Object.Destroy);
			//Destroy the menu after tween is complete.

		}
	}
}