using System;
using Zenkoban.Extensions.Utility.Collections;

namespace Zenkoban.Utils
{
	public class IndexCycler
	{
		private Array indexable;
		private int current;

		public static implicit operator int(IndexCycler cycler) => cycler.current;

		public IndexCycler(Array indexable, int current)
		{
			this.indexable = indexable;
			this.current = current;
		}

		public void Inc()
		{
			if (indexable.IsLast(current))
			{
				current = 0;
				return;
			}

			current++;
		}

		public void Dec()
		{
			current--;
			if (current < 0)
			{
				current = indexable.Length - 1;
			}
		}
	}
}