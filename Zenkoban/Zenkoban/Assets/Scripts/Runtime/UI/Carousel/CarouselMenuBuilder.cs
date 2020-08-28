using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Runtime.UI.Core;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class CarouselMenuBuilder : SerializedMonoBehaviour
	{
		[SerializeField]
		private CarouselMenu prefab = null;
		
		public CarouselMenu Build(IEnumerable<ICarouselPanel> newPanels)
		{
			var carouselMenu = Instantiate(prefab);
			
			carouselMenu.Initialize(newPanels);

			return carouselMenu;
		}
	}
}