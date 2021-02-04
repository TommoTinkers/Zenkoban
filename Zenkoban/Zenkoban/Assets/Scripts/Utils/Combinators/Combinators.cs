using System;

namespace Zenkoban.Utils.Combinators
{
	public static class Combinators
	{
		public static Func<Action, Action> IfThen(Func<bool> predicate)
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