namespace Zenkoban.Extensions
{
	public static class FloatExtensions
	{
		public static float AddAPercentage(this float value, float percentage)
		{
			return value + (value * percentage);
		}
	}
}