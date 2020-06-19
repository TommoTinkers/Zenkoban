using System;

namespace Zenkoban.Runtime.Data.Levels
{
	public class Tile
	{
		public TileType Type { get; }

		public Tile(TileType type)
		{
			Type = type;
		}
	}
}