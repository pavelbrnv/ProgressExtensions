using System;

namespace ProgressExtensions
{
	public sealed class ProgressValueAdapter : IProgressValueUpdater
	{
		private readonly IProgressValueUpdater updater;
		private readonly float fullWidth;
		private readonly float updaterFullWidth;

		public float MinValue { get; }

		public float MaxValue { get; }

		public ProgressValueAdapter(IProgressValueUpdater updater, float minValue, float maxValue)
		{
			this.updater = updater ?? throw new ArgumentNullException(nameof(updater));

			if (maxValue < minValue) (minValue, maxValue) = (maxValue, minValue);
			MinValue = minValue;
			MaxValue = maxValue;

			fullWidth = MaxValue - MinValue;
			updaterFullWidth = updater.MaxValue - updater.MinValue;
		}

		public void Update(float value)
		{
			var width = value - MinValue;
			var part = width / fullWidth;
			
			var updaterWidth = updaterFullWidth * part;
			var updaterValue = updater.MinValue + updaterWidth;

			updater.Update(updaterValue);
		}
	}
}
