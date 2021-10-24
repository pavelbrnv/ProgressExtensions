using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgressExtensions
{
	public sealed class ProgressValueAggregator : IProgressValueUpdater
	{
		private readonly IProgressValueUpdater[] adapters;

		public float MinValue { get; }

		public float MaxValue { get; }

		public ProgressValueAggregator(float minValue, float maxValue, IEnumerable<IProgressValueUpdater> updaters)
		{
			if (updaters == null) throw new ArgumentNullException(nameof(updaters));

			if (maxValue < minValue) (minValue, maxValue) = (maxValue, minValue);
			MinValue = minValue;
			MaxValue = maxValue;

			adapters = updaters
				.Select(updater => updater.GetValueAdapter(minValue, maxValue))
				.ToArray();
		}

		public ProgressValueAggregator(float minValue, float maxValue, params IProgressValueUpdater[] updaters)
			: this(minValue, maxValue, (IEnumerable<IProgressValueUpdater>)updaters)
		{
		}

		public void Update(float value)
		{
			foreach (var adapter in adapters)
			{
				adapter.Update(value);
			}
		}
	}
}
