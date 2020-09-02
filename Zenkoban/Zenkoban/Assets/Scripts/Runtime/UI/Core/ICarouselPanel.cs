using UnityEngine;

namespace Zenkoban.Runtime.UI.Core
{
	public interface ICarouselPanel
	{
		Transform transform { get; }
		
		Canvas Canvas { get; }
		
		void Enable();
		void Disable();
	}
}