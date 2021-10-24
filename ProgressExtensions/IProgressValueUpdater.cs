namespace ProgressExtensions
{
	public interface IProgressValueUpdater
	{
		float MinValue { get; }

		float MaxValue { get; }

		void Update(float value);
	}
}
