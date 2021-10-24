using System;
using ProgressExtensions.Common;

namespace ProgressExtensions
{
	public interface IProgressValueIndicator
	{
		float MinValue { get; }

		float MaxValue { get; }

		float Value { get; }

		event EventHandler<SingleValueChangedEventArgs> ValueChanged;
	}
}
