using System;
using DG.Tweening;
using Zenkoban.Settings;

namespace Zenkoban.Runtime.UI.Carousel.Movement
{
	public class CarouselMenuTweenStrategy : ICarouselTweeningStrategy
	{
		private const float duration = GameSettings.CarouselInOutDuration;
		
		public void Out(CarouselMenu menu, Action<CarouselMenu> callback) => Tween(menu, callback, -15f, duration);

		public void In(CarouselMenu menu, Action<CarouselMenu> callback) => Tween(menu, callback, 0f, duration);
		private void Tween(CarouselMenu menu, Action<CarouselMenu> action, float yValue, float duration)
		{
			var anim = menu.transform.DOMoveY(yValue, duration);
            anim.OnComplete(() => action(menu));
            anim.Play();
		}
	}
}