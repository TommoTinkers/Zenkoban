using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;

namespace Zenkoban.Assets.Flow.Levels
{
	[CreateAssetMenu(fileName = "LevelEntry", menuName = "Zenkoban/Game/Level Set Entry")]
	public class LevelEntry : SerializedScriptableObject
	{
		[SerializeField]
		private LevelAsset _level;
	}
}