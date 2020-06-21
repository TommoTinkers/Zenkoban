using UnityEngine;
using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Views.Level.Objects;

namespace Zenkoban.Runtime.Views.Level.Instantiators
{
	public class InstantiatedLevelView
	{
		public LevelSize Size { get; }
		public Vector3[,] Positions { get; }
		public GameBlock[,] Blocks { get; }

		public InstantiatedLevelView(LevelSize size, Vector3[,] positions, GameBlock[,] blocks)
		{
			Size = size;
			Positions = positions;
			Blocks = blocks;
		}
	}
}