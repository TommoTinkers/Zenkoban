using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Data;

#if UNITY_EDITOR
using Sirenix.Utilities.Editor;
#endif

namespace Zenkoban.Assets.Levels
{
	[CreateAssetMenu(fileName = "Level", menuName = "Zenkoban/Create new level.")]
	public class LevelAsset : SerializedScriptableObject
	{
		[SerializeField]
		[TableMatrix(HorizontalTitle = "Level grid", SquareCells = true, DrawElementMethod = "DrawTileAsset")]
		private TileType[,] tiles;

		
		#region Editor
		
		[ShowInInspector]
		private static LevelSize levelSize = new LevelSize(); 
		
		private static TileType current = TileType.Wall;
		
		[Button]
		private void ResizeLevel()
		{
			tiles = new TileType[levelSize.Width, levelSize.Height];
		}
		
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
		}
		
		#endregion
	}
}