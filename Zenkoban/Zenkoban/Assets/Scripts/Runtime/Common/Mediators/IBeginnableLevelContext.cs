using System;

namespace Zenkoban.Runtime.Common.Mediators
{
	public interface IBeginnableLevelContext
	{
		void Begin(Action onCompleteCallback);
	}
}