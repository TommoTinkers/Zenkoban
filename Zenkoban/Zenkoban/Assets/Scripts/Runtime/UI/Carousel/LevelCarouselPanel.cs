using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Runtime.UI.Core;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class LevelCarouselPanel : SerializedMonoBehaviour, ICarouselPanel
	{
		[SerializeField]
		private Canvas canvas = null;
		
		public Canvas Canvas => canvas;

		public void Enable()
		{
			
		}

		public void Disable()
		{
			
		}
	}
}