using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;
using Zenkoban.Extensions.Utility.Collections;

namespace Zenkoban.Assets.Flow.Levels
{
	[CreateAssetMenu(fileName = "LevelSet", menuName = "Zenkoban/Game/Level Set")]
	public class LevelSet : SerializedScriptableObject
	{
		[SerializeField]
		private string setName = null;
		
		[SerializeField]
		private LevelAsset[] levels = null;
		
		public string SetName => setName;
		public IEnumerable<LevelAsset> AllLevels => levels;

		public LevelAsset this[int index]
		{
			get
			{
				if (levels.IsValidIndex(index))
				{
					return levels[index];
				}
				
				throw new Exception($"Level index out of bounds. Tried to access level {index} in {setName}");
			}
		}
	}
}