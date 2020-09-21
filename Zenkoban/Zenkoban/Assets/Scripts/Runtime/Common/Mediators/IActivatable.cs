namespace Zenkoban.Runtime.Common.Mediators
{
	public interface IActivatable
	{
		void SetActive();
		void SetInactive();
	}
}