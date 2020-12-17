using UnityEngine;

namespace Zenkoban.Runtime.Views.Level.Ambience
{
	public class Rotator : MonoBehaviour
	{
		[SerializeField]
		private Vector3 axes = new Vector3(1f, 0f, 0f);
		[SerializeField]
		private float speed = 1f;
		
		private void Update()
		{
			transform.Rotate(axes, speed * Time.deltaTime);	
		}
	}
}