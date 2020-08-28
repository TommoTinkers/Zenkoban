using System;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEditor.U2D;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;
using Zenkoban.Runtime.UI.Carousel;
using Zenkoban.Runtime.UI.Core;

namespace Zenkoban.Runtime.UI.LevelSelect
{
	public class LevelSetPicker : SerializedMonoBehaviour
	{
		public event Action<LevelSet> OnLevelSetPicked;
		
		[SerializeField] private GameLevelsConfiguration levels = null;

		[SerializeField]
		private LevelSetCarouselPanel panelPrefab = null;
		
		[SerializeField]
		private CarouselMenuBuilder carouelMenuBuilder = null;
		
		public Transform CreatePicker()
		{
			var panels = levels.MainLevels.Select(set => Instantiate(panelPrefab)).ToArray();
			var carouselMenu = carouelMenuBuilder.Build(panels);
			
			carouselMenu.OnItemSelected += HandleItemSelected;
			return carouselMenu.transform;
		}
		
		private void HandleItemSelected(ICarouselPanel obj, int index)
		{
			var set = levels.MainLevels.ToArray()[index];
			OnLevelSetPicked?.Invoke(set);
		}
	}
}