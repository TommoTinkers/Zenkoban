using System;
using UnityEngine;

namespace Zenkoban.Data.Levels
{
	public class LevelSize
	{
		
		private readonly int width = 20;
		
		private readonly int height = 20;
		
		public int Width => width;

		public int Height => height;

		public LevelSize()
		{
		}

		public LevelSize(int w, int h)
		{
			width = w;
			height = h;
		}
		
	}
}