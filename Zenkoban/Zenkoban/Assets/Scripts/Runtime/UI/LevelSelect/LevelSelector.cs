using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;

namespace Zenkoban.Runtime.UI.LevelSelect
{
	public class LevelSelector : SerializedMonoBehaviour
	{
		[SerializeField] private LevelSetPicker levelSetPicker = null;
		[SerializeField] private LevelPicker levelPicker = null;
		
		private Transform setPicker;
		private Transform picker;
		
		private void Awake()
		{
			levelSetPicker.OnLevelSetPicked += HandleLevelSetPicked;
			levelPicker.OnBackSelected += ShowLevelSetPicker;
			CreatePickers();
			ShowLevelSetPicker();
		}

		private void CreatePickers()
		{
			setPicker = levelSetPicker.CreatePicker();
			setPicker.position = Vector3.down * 25f;
		}

		private void HandleLevelSetPicked(LevelSet set)
		{
			picker = levelPicker.CreatePicker(set);
			
			picker.position = Vector3.up * 25;

			setPicker.DOMove(Vector3.down * 25, 1f).Play();
			picker.DOJump(Vector3.zero, 2f, 3, 1f).Play();
		}

		private void ShowLevelSetPicker()
		{
			if (picker != null)
			{
				picker.DOMove(Vector3.up * 25f, 1f).Play();
			}
			setPicker.DOJump(Vector3.zero, 2f, 3, 1f).Play();
		}
	}
}