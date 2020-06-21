using System;
using UnityEngine;

namespace Zenkoban.Runtime.Views.Level.Objects
{
	public class GameBlock : MonoBehaviour
	{
		public Guid Id { get; private set; }

		public Vector3 Offset => offset;

		[SerializeField]
		private Vector3 offset = Vector3.up * 5f;

		public void SetId(Guid id)
		{
			Id = id;
		}
	}
}