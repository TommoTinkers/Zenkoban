using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Data.Levels;
#if UNITY_EDITOR
using Sirenix.Utilities.Editor;
#endif

namespace Zenkoban.Assets.Levels
{
	[CreateAssetMenu(fileName = "Level", menuName = "Zenkoban/Create new level.")]
	public class LevelAsset : SerializedScriptableObject, ILevelAsset
	{
		[SerializeField]
		[TableMatrix(HorizontalTitle = "Level grid", SquareCells = true, DrawElementMethod = "DrawTileAsset")]
		private TileType[,] tiles = new TileType[20,20];

		public TileType[,] Tiles => tiles;

		public LevelSize Size => size;

		private LevelSize size => new LevelSize(tiles.GetLength(0), tiles.GetLength(1));

		[SerializeField]
		private Guid Id = Guid.NewGuid();

		#region Editor
		
		private static TileType current = TileType.Wall;
		

		private static TileType DrawTileAsset(Rect rect, TileType currentTile)
		{
			if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
			{
				currentTile = current;
				GUI.changed = true;
				Event.current.Use();
			}

			Color color;
			
			switch(currentTile)
			{
				case TileType.Empty:
					color = Color.white;
					break;
				case TileType.Floor:
					color = Color.black;
					break;
				case TileType.Wall:
					color = Color.gray;
					break;
				case TileType.Player:
					color = Color.red;
					break;
				case TileType.Block:
					color = Color.yellow;
					break;
				case TileType.Goal:
					color = Color.cyan;
					break;
				case TileType.BlockOnGoal:
					color = Color.green;
					break;
				case TileType.MirrorBlock:
					color = Color.blue;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
#if UNITY_EDITOR
			SirenixEditorGUI.DrawSolidRect(rect, color);
#endif
			return currentTile;
		}
		
		[OnInspectorGUI]
		private static void OnInspectorGUI()
		{
			if (GUILayout.Button("EMPTY"))
			{
				current = TileType.Empty;
			}
			
			if (GUILayout.Button("WALL"))
			{
				current = TileType.Wall;
			}

			if (GUILayout.Button("FLOOR"))
			{
				current = TileType.Floor;
			}

			if (GUILayout.Button("PLAYER"))
			{
				current = TileType.Player;
			}
			
			if (GUILayout.Button("BLOCK"))
			{
				current = TileType.Block;
			}
			
			if (GUILayout.Button("GOAL"))
			{
				current = TileType.Goal;
			}
			
			if (GUILayout.Button("BLOCK ON GOAL"))
			{
				current = TileType.BlockOnGoal;
			}
			
			if (GUILayout.Button("MIRROR BLOCK"))
			{
				current = TileType.MirrorBlock;
			}
		}
		
		#endregion
	}
}