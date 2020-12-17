using UnityEngine;
using Random = System.Random;

namespace Zenkoban.Extensions
{
	public static class RandomExtensions
	{
		public static bool NextBool(this Random random)
		{
			var num = random.Next(0, 2);
			return num == 1 ? true : false;
		}

		public static Vector3 Axes(this Random random)
		{
			var x = (float)random.NextDouble();
			var y = (float)random.NextDouble();
			var z = (float)random.NextDouble();
			
			return new Vector3(x, y, z);
		}
	}
}