using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;
using Zenkoban.Runtime.UI.Carousel.Movement;

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
				CreateRootMenu,
				CreateLevelMenu
			};
			
			compoundCarouselMenu = new CompoundCarouselMenu(menuCreators, new CarouselMenuTweenStrategy());
		}

		private CarouselMenu CreateRootMenu(int index)
		{
			var panels = gameLevels.MainLevels.Select(set => Instantiate(levelSetPanelPrefab)).ToArray();
			return carouselMenuBuilder.Build(panels, index);
		}

		private CarouselMenu CreateLevelMenu(int index)
		{
			return null;
		}
	}
}