using UnityEngine;
using Zenkoban.Extensions;

namespace Zenkoban.Runtime.Views.Level.Ambience
{
	public class RandomRotator : MonoBehaviour
	{
		[SerializeField]
		private float speed = 1f;

		private Vector3 rotationAxes;
		
		private void Awake()
		{
			rotationAxes = new System.Random().Axes();
		}

		private void Update()
		{
			transform.Rotate(rotationAxes, speed * Time.deltaTime);	
		}
	}
}