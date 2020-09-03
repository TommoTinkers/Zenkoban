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


		public void SetTitle(string title)
		{
			levelSetTitle.text = title;
		}
		
		public void Enable()
		{
			
		}

		public void Disable()
		{
			
		}
	}
}