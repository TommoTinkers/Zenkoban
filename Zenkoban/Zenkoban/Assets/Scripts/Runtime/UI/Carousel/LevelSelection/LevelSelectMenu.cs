using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;

namespace Zenkoban.Runtime.UI.Carousel.LevelSelection
{
	public class LevelSelectMenu : MonoBehaviour
	{
		[SerializeField] private GameLevelsConfiguration gameLevels = null;
		[SerializeField] private LevelSetCarouselPanel levelSetPanelPrefab = null;
		[SerializeField] private CarouselMenu carouselMenuPrefab = null;
		
		private CarouselMenuBuilder carouselMenuBuilder;
		private CompoundCarouselMenu compoundCarouselMenu;
		
		private void Awake()
		{
			carouselMenuBuilder = new CarouselMenuBuilder(carouselMenuPrefab);

			var menuCreators = new List<Func<int, CarouselMenu>>
			{
				CreateRootMenu
			};
			
			compoundCarouselMenu = new CompoundCarouselMenu(menuCreators);
		}

		private CarouselMenu CreateRootMenu(int index)
		{
			var panels = gameLevels.MainLevels.Select(set => Instantiate(levelSetPanelPrefab)).ToArray();
			return carouselMenuBuilder.Build(panels, index);
		}
	}
}