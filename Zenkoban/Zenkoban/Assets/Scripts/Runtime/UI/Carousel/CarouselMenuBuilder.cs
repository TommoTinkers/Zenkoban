using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Runtime.UI.Core;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class CarouselMenuBuilder
	{
		private readonly CarouselMenu prefab = null;

		public CarouselMenuBuilder(CarouselMenu prefab)
		{
			this.prefab = prefab;
		}

		public CarouselMenu Build(IEnumerable<ICarouselPanel> newPanels, int index = 0)
		{
			var carouselMenu = Object.Instantiate(prefab);
			
			carouselMenu.Initialize(newPanels);

			return carouselMenu;
		}
	}
}