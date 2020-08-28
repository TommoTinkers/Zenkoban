using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;
using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.UI.Carousel;
using Zenkoban.Runtime.UI.Core;

namespace Zenkoban.Runtime.UI.LevelSelect
{
	public class LevelPicker : SerializedMonoBehaviour
	{
		public event Action<LevelAsset> OnLevelPicked;
		public event Action OnBackSelected;
		
		[SerializeField] 
		private LevelCarouselPanel panelPrefab = null;

		[SerializeField]
		private CarouselMenuBuilder carouselMenuBuilder = null;
		
		public Transform CreatePicker(LevelSet levelSet)
		{
			var panels = levelSet.AllLevels().Select(set => Instantiate(panelPrefab)).ToArray();
			var carouselMenu = carouselMenuBuilder.Build(panels);

			Action<ICarouselPanel, int> handleItemSelectedCallback = (panel, i) =>
			{
				HandleItemSelected(levelSet, i);
			};
			carouselMenu.OnItemSelected += handleItemSelectedCallback;
			carouselMenu.OnUserChoseBack += () => OnBackSelected?.Invoke();
			return carouselMenu.transform;
		}

		private void HandleItemSelected(LevelSet set, int selectedIndex)
		{
			OnLevelPicked?.Invoke(set[selectedIndex]);
		}
	}
}