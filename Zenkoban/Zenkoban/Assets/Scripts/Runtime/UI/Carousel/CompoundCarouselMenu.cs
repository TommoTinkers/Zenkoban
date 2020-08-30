using System;
using System.Collections.Generic;
using Zenkoban.Extensions.Utility.Collections;
using Zenkoban.Runtime.UI.Core;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class CompoundCarouselMenu
	{
		private IList<Func<int, CarouselMenu>> carouselMenuCreators;

		private CarouselMenu currentCarouselMenu;
		
		private int currentIndex = 0;

		public CompoundCarouselMenu(IList<Func<int, CarouselMenu>> carouselMenuCreators, int rootMenuStartIndex = 0)
		{
			this.carouselMenuCreators = carouselMenuCreators;
			currentCarouselMenu = carouselMenuCreators[0]?.Invoke(rootMenuStartIndex);
			currentCarouselMenu.OnItemSelected += HandleCarouselItemSelected;
		}

		private void HandleCarouselItemSelected(ICarouselPanel panel, int index)
		{
			var destination = currentIndex + 1;
			if (carouselMenuCreators.IsNotLast(destination))
			{
				//Tween out the current menu.
				//Bring in the new menu.	
			}

			if (carouselMenuCreators.IsLast(destination))
			{
				//This means the user has selected an item. Invoke the item chosen event.
				//Tween out the current menu ?? 
			}
			
		}
	}
}