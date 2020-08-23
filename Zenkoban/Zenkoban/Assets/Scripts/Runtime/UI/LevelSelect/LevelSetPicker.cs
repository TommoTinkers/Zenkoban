using System.Linq;
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
		private CarouselMenu carouselMenu = null;

		private void Awake()
		{
			var panels = levelSet.Select(set => Instantiate(panelPrefab).gameObject).ToArray();
			carouselMenu.Initialize(panels);
				
		}
	}
}