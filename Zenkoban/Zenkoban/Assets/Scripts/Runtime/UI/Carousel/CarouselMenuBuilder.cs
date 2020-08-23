using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class CarouselMenuBuilder : SerializedMonoBehaviour
	{
		[SerializeField]
		private CarouselMenu prefab = null;
		
		public CarouselMenu Build(IEnumerable<GameObject> newPanels)
		{
			var carouselMenu = Instantiate(prefab);
			
			carouselMenu.Initialize(newPanels);

			return carouselMenu;
		}
	}
}