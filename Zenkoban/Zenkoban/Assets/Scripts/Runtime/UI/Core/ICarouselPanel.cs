using UnityEngine;

namespace Zenkoban.Runtime.UI.Core
{
	public interface ICarouselPanel
	{
		Transform transform { get; }
		
		void Enable();
		void Disable();
	}
}