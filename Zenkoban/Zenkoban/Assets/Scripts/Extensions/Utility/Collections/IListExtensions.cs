using System.Collections;
using System.Collections.Generic;

namespace Zenkoban.Extensions.Utility.Collections
{
	public static class IListExtensions
	{
		public static bool IsLast(this IList list, int index)
		{
			return index == list.Count - 1;
		}
		
		public static bool IsLast<T>(this IList<T> list, int index)
		{
			return index == list.Count - 1;
		}
		
		public static bool IsNotLast<T>(this IList<T> list, int index)
		{
			return index < list.Count - 1;
		}

		public static bool IsNotFirst<T>(this IList<T> list, int index)
		{
			return index > 0 && list.Count >= 1;
		}

		public static bool IsValidIndex<T>(this IList<T> list, int index)
		{
			return list != null &&
			       index >= 0 &&
			       index < list.Count;
		}

		public static int ThisIndexOrMax<T>(this IList<T> list, int index)
		{
			if (list.IsValidIndex(index))
			{
				return index;
			}

			return list.Count - 1;
		}

		public static int ThisIndexOrMin<T>(this IList<T> list, int index)
		{
			return list.IsValidIndex(index) ? index : 0;
		}
	}
}