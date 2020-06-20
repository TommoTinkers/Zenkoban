using UnityEngine;
using Zenkoban.Runtime.Views.Level.Objects;

namespace Zenkoban.Runtime.Views.Level
{
	public interface ILevelTheme
	{
		GameBlock Player { get; }
		GameBlock Block { get; }
		GameObject Floor { get; }
		GameObject Wall { get; }
	}
}