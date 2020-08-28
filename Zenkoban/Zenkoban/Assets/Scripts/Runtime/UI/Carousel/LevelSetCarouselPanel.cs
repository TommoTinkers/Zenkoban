using TMPro;
using UnityEngine;
using Zenkoban.Runtime.UI.Core;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class LevelSetCarouselPanel : MonoBehaviour, ICarouselPanel
	{
		[SerializeField]
		private Canvas canvas = null;
		
		[SerializeField]
		private TMP_Text levelSetTitle = null;
		
		public Canvas Canvas => canvas;
		
		public void Enable()
		{
			levelSetTitle.text = "Enabled";
		}

		public void Disable()
		{
			levelSetTitle.text = "Disabled";
		}
	}
}