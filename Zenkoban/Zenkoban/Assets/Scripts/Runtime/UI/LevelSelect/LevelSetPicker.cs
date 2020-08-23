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
		[SerializeField]
		private LevelSet[] levelSet = null;

		[SerializeField]
		private LevelSetCarouselPanel panelPrefab = null;
		
		[SerializeField]
		private CarouselMenuBuilder carouelMenuBuilder = null;

		private void Start()
		{
			var panels = levelSet.Select(set => Instantiate(panelPrefab).gameObject).ToArray();
			var carouselMenu = carouelMenuBuilder.Build(panels);
			carouselMenu.transform.position = Vector3.down * 25f;
			carouselMenu.transform.DOJump(Vector3.zero, 2f, 3, 1f).Play();

		}
	}
}