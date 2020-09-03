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

		[SerializeField] private LevelCarouselPanel levelCarouselPanelPrefab = null;
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
			var panels = gameLevels.MainLevels.Select(set =>
			{
				var panel =  Instantiate(levelSetPanelPrefab);
				panel.SetTitle(set.SetName);
				return panel;
			}).ToArray();
			
			var menu =  carouselMenuBuilder.Build(panels, index);
			menu.transform.Translate(Vector3.up * 25f);
			
			return menu;
		}

		private CarouselMenu CreateLevelMenu(int index)
		{
			var levels = gameLevels.MainLevels[index].AllLevels();
			var panels = levels.Select(level => Instantiate(levelCarouselPanelPrefab)).ToArray();
			
			var menu = carouselMenuBuilder.Build(panels, 0);
			menu.transform.Translate(Vector3.up * 25f);
			return menu;
		}
	}
}