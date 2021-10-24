using System;
using ProgressExtensions.Common;

namespace ProgressExtensions
{
	public static class Extensions
	{
		#region Reseting
		
		public static void Reset(this IProgressValueUpdater updater)
		{
			if (updater == null) throw new ArgumentNullException(nameof(updater));

			updater.Update(updater.MinValue);
		}

		public static void SetFull(this IProgressValueUpdater updater)
		{
			if (updater == null) throw new ArgumentNullException(nameof(updater));

			updater.Update(updater.MaxValue);
		}

		#endregion

		#region Value adapter

		public static IProgressValueUpdater GetValueAdapter(this IProgressValueUpdater updater, float minValue, float maxValue)
		{
			if (updater == null) throw new ArgumentNullException(nameof(updater));

			if (updater.MinValue.AlmostEqual(minValue) && updater.MaxValue.AlmostEqual(maxValue))
			{
				return updater;
			}

			return new ProgressValueAdapter(updater, minValue, maxValue);
		}

		#endregion
	}
}
