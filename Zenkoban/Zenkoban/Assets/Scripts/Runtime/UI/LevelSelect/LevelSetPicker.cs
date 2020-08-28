using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;
using Zenkoban.Runtime.UI.Carousel;

namespace Zenkoban.Runtime.UI.LevelSelect
{
	public class LevelSetPicker : SerializedMonoBehaviour
	{
		[SerializeField] private GameLevelsConfiguration levels = null;

		[SerializeField]
		private LevelSetCarouselPanel panelPrefab = null;
		
		[SerializeField]
		private CarouselMenuBuilder carouelMenuBuilder = null;

		private void Start()
		{
			var panels = levels.MainLevels.Select(set => Instantiate(panelPrefab)).ToArray();
			var carouselMenu = carouelMenuBuilder.Build(panels);
			carouselMenu.transform.position = Vector3.down * 25f;
			carouselMenu.transform.DOJump(Vector3.down, 2f, 3, 1f).Play();

		}
	}
}