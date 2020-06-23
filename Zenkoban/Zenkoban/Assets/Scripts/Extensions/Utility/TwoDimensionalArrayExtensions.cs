using System;

namespace Zenkoban.Extensions.Utility
{
	public static class TwoDimensionalArrayExtensions
	{
		public static (int x, int y) IndexOf<T>(this T[,] array, Func<T, bool> predicate)
		{
			for (var x = 0; x <= array.GetUpperBound(0); x++)
			{
				for (var y = 0; y <= array.GetUpperBound(1); y++)
				{
					var element = array[x, y];
					if (predicate(element))
					{
						return (x, y);
					}
				}
			}

			return (-1, -1);
		}
		
	}
}