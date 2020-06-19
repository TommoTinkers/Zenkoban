using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Runtime.Views.Level.Objects;

namespace Zenkoban.Runtime.Views.Level
{
	[CreateAssetMenu(fileName = "LevelTheme", menuName = "Zenkoban/Create level theme configuration.")]
	public class LevelTheme : SerializedScriptableObject, ILevelTheme
	{
		public GameBlock Player => player;

		public GameBlock Block => block;

		public GameObject Tile => tile;

		public GameObject Wall => wall;

		[SerializeField]
		private GameBlock player;

		[SerializeField]
		private GameBlock block;

		[SerializeField]
		private GameObject tile;

		[SerializeField]
		private GameObject wall;
	}
}