using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;
using Zenkoban.Runtime.Levels.Loading;
using Zenkoban.Runtime.Views.Level.Instantiators;

namespace Zenkoban.Runtime.Views.Level
{
	public class LevelView : SerializedMonoBehaviour
	{
		[SerializeField]
		private ILevelAsset levelAsset = null;

		[SerializeField]
		private ILevelLoader levelLoader = null;

		[SerializeField]
		private ILevelTheme levelTheme = null;
		
		private Vector3[,] positions;
		
		[Button("TestLevelInstantiation")]
		private void TestLevelInstantiation()
		{
			LevelInstantiator.InstantiateLevel(levelLoader.Load(levelAsset), levelTheme, transform);	
		}
	}
}