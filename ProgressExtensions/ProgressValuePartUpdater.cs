using System;

namespace ProgressExtensions
{
	public sealed class ProgressValuePartUpdater : IProgressValueUpdater
	{
		private readonly IProgressValueUpdater updater;

		private readonly float partMinValue;
		private readonly float partWidth;

		public float MinValue => updater.MinValue;

		public float MaxValue => updater.MaxValue;

		public ProgressValuePartUpdater(IProgressValueUpdater updater, float partMinValue, float partMaxValue)
		{
			this.updater = updater ?? throw new ArgumentNullException(nameof(updater));

			if (partMaxValue < partMinValue)
			{
				(partMinValue, partMaxValue) = (partMaxValue, partMinValue);
			}

			if (partMinValue < updater.MinValue)
			{
				throw new AggregateException("Part min value should be equals or greater than updater min value");
			}
			if (updater.MaxValue < partMaxValue)
			{
				throw new AggregateException("Part max value should be equals or less than updater max value");
			}

			this.partMinValue = partMinValue;

			partWidth = partMaxValue - partMinValue;
		}

		public void Update(float value)
		{
			var progressPart = (value - MinValue) / (MaxValue - MinValue);
			var adaptedValue = MinValue + partMinValue + (progressPart * partWidth);
			updater.Update(adaptedValue);
		}
	}
}
