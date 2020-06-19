using System;
using UnityEngine;

namespace Zenkoban.Data.Levels
{
	[Serializable]
	public class LevelSize
	{
		[SerializeField]
		private int width = 32;

		[SerializeField]
		private int height = 18;

		public int Width => width;

		public int Height => height;
	}
}