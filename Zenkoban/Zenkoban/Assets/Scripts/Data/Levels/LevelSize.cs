using System;
using UnityEngine;

namespace Zenkoban.Data.Levels
{
	[Serializable]
	public class LevelSize
	{
		[SerializeField]
		private int width = 20;

		[SerializeField]
		private int height = 20;
		
		public int Width => width;

		public int Height => height;
	}
}