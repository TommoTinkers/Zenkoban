using System;
using Sirenix.OdinInspector;
using Zenkoban.Runtime.Flow.Levels.EndOfLevel;

namespace Zenkoban.Runtime.UI.EndOfLevel
{
	public class EndOfLevelMenu : SerializedMonoBehaviour
	{
		public event Action<EndOfLevelChoice> OnUserChoose;
		
		public void Initialise()
		{
			OnUserChoose?.Invoke(EndOfLevelChoice.Repeat);
		}
	}
}