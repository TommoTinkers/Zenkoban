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

		public GameObject Floor => floor;
		
		public GameObject Goal => goal;

		public GameBlock Wall => wall;

		[SerializeField]
		private GameBlock player = null;

		[SerializeField]
		private GameBlock block = null;

		[SerializeField]
		private GameObject floor = null;

		[SerializeField]
		private GameObject goal = null;
		
		[SerializeField]
		private GameBlock wall = null;
		
		
	}
}