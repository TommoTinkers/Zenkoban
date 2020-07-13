using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Zenkoban.Runtime.Views.Level.Objects
{
	public class ColorableGoalBlock : SerializedMonoBehaviour
	{
		[SerializeField]
		private Color albedo = Color.cyan;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color emissive = Color.cyan;

		private Material material;

		private Color albedoDefault;
		private Color emissiveDefault;
		private static readonly int emissionColor = Shader.PropertyToID("_EmissionColor");
		private static readonly int baseColor = Shader.PropertyToID("_BaseColor");

		private void Awake()
		{
			material = GetComponent<Renderer>().material;
			albedoDefault = material.GetColor(baseColor);
			emissiveDefault = material.GetColor(emissionColor);
		}
		
		public void ColorToOnGoal()
		{
		
			material.DOColor(albedo, 0.2f).Play();
			material.DOColor(emissive, "_EmissionColor", 0.2f).Play();
		}

		public void ColorToOffGoal()
		{
			material.DOColor(albedoDefault, 0.2f).Play();
			material.DOColor(emissiveDefault, "_EmissionColor", 0.2f).Play();
		}
	}
}