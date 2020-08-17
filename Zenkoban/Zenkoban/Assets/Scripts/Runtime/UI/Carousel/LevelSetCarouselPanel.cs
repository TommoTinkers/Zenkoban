using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Zenkoban.Runtime.UI.Carousel
{
	public class LevelSetCarouselPanel : MonoBehaviour
	{
		[SerializeField]
		private Image levelSetThumbnail;
		
		[SerializeField]
		private TMP_Text levelSetTitle;

		[SerializeField]
		private TMP_Text completedCount;

		[SerializeField]
		private TMP_Text starsCount;
	}
}