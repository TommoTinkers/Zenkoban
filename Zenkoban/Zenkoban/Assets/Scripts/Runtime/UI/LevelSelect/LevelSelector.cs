using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Flow.Levels;

namespace Zenkoban.Runtime.UI.LevelSelect
{
	[SerializeField]
	public class LevelSelector : SerializedMonoBehaviour
	{
		[SerializeField] private LevelSetPicker levelSetPicker = null;
		[SerializeField] private LevelPicker levelPicker = null;

		private void Awake()
		{
			ShowLevelSetPicker();
			levelSetPicker.OnLevelSetPicked += HandleLevelSetPicked;
		}

		private void HandleLevelSetPicked(LevelSet obj)
		{
			var picker = levelPicker.CreatePicker(obj);
			picker.position = Vector3.up * 25;
			picker.DOJump(Vector3.up, 2f, 3, 1f).Play();
		}

		private void ShowLevelSetPicker()
		{
			var picker = levelSetPicker.CreatePicker();
			picker.position = Vector3.down * 25f;
			picker.DOJump(Vector3.down, 2f, 3, 1f).Play();
		}
	}
}