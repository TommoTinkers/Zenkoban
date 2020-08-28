using System;
using UnityEngine;

namespace Zenkoban.Input.Movement
{
	public class CarouselInputProvider : MonoBehaviour, ICarouselInputProvider
	{
		private Controls controls;
		public event Action OnCycleLeft;
		public event Action OnCycleRight;
		public event Action OnSelect;
		public event Action OnBack;
		
		private void Awake()
		{
			controls = new Controls();
			var carouselControls = controls.Carousel;
			carouselControls.CycleLeft.performed += a => OnCycleLeft?.Invoke();
			carouselControls.CycleRight.performed += a => OnCycleRight?.Invoke();
			carouselControls.Select.performed += a => OnSelect?.Invoke();
			carouselControls.Back.performed += a => OnBack?.Invoke();
		}
		
		private void OnEnable()
		{
			controls.Enable();
		}

		private void OnDisable()
		{
			controls.Disable();
		}
	}
}