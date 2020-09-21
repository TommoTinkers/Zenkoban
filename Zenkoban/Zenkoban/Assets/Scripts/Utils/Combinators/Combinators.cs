using System;

namespace Zenkoban.Utils.Combinators
{
	public static class Combinators
	{
		public static Func<Action, Action> If(Func<bool> predicate)
		{
			return actionToTakeOnSuccess =>
			{
				return () =>
				{
					if (predicate?.Invoke() ?? false)
					{
						actionToTakeOnSuccess?.Invoke();
					}
				};
			};
		}
	}
}