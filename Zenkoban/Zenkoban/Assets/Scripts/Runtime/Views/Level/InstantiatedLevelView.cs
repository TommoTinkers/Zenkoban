using System;
using System.Collections.Generic;
using UnityEngine;
using Zenkoban.Data.Levels;
using Zenkoban.Runtime.Views.Level.Objects;

namespace Zenkoban.Runtime.Views.Level
{
	public class InstantiatedLevelView
	{
		public LevelSize Size { get; }
		public Vector3[,] Positions { get; }

		public IReadOnlyDictionary<Guid, GameBlock> Blocks => blocks;
		
		private readonly Dictionary<Guid, GameBlock> blocks;
		
		public InstantiatedLevelView(LevelSize size, Vector3[,] positions, GameBlock[,] gameBlocks)
		{
			Size = size;
			Positions = positions;

			blocks = new Dictionary<Guid, GameBlock>();
			
			for (var x = 0; x < size.Width; x++)
			{
				for (var y = 0; y < size.Height; y++)
				{
					var block = gameBlocks[x, y];
					if (block != null)
					{
						blocks[block.Id] = block;
					}
				}
			}
		}
	}
}