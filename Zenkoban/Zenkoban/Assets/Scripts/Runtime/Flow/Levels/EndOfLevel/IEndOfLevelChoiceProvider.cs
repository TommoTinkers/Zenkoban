using System;

namespace Zenkoban.Runtime.Flow.Levels.EndOfLevel
{
	public interface IEndOfLevelChoiceProvider
	{
		void GetChoice(Action<EndOfLevelChoice> callback);
	}
}