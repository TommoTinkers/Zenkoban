using System;
using System.Collections.Generic;
using Zenkoban.Runtime.Data.Movement;

namespace Zenkoban.Runtime.Common
{
	public interface IMoveCommandProvider
	{
		event Action<IEnumerable<MoveNotification>, Action> OnMove;
	}
}