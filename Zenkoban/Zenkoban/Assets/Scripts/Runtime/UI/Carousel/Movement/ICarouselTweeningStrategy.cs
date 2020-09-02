using System;

namespace Zenkoban.Runtime.UI.Carousel.Movement
{
	public interface ICarouselTweeningStrategy
	{
		void Out(CarouselMenu menu, Action<CarouselMenu> callback);
		void In(CarouselMenu menu, Action<CarouselMenu> callback);
	}
}