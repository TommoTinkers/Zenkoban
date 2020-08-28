using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Zenkoban.Runtime.UI.LevelSelect
{
	[SerializeField]
	public class LevelSelector : SerializedMonoBehaviour
	{
		[SerializeField] private LevelSetPicker levelSetPicker = null;
		
		private void Awake()
		{
			ShowLevelSetPicker();	
		}

		private void ShowLevelSetPicker()
		{
			var picker = levelSetPicker.CreatePicker();
			picker.position = Vector3.down * 25f;
			picker.DOJump(Vector3.down, 2f, 3, 1f).Play();
		}
	}
}