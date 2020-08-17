using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Zenkoban.Assets.Flow.Levels
{
	[CreateAssetMenu(fileName = "LevelSet", menuName = "Zenkoban/Game/Level Set")]
	public class LevelSet : SerializedScriptableObject
	{
		[SerializeField]
		private Dictionary<Guid,LevelEntry> levels = new Dictionary<Guid, LevelEntry>();

		[SerializeField]
		private Dictionary<Guid, LevelEntry> bonusLevels = new Dictionary<Guid, LevelEntry>();
	}
}