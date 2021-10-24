using System;
using ProgressExtensions.Common;

namespace ProgressExtensions
{
	public class ValueProgress : IProgressValueUpdater, IProgressValueIndicator
	{
		#region Properties

		public float MinValue { get; }

		public float MaxValue { get; }

		public float Value { get; private set; }

		#endregion

		#region Ctor

		public ValueProgress(float minValue, float maxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;

			this.Reset();
		}

		#endregion

		#region Events

		public event EventHandler<SingleValueChangedEventArgs> ValueChanged = delegate { };
		
		#endregion

		#region Events raisers

		private void OnValueChanged(float oldValue, float newValue)
		{
			var args = new SingleValueChangedEventArgs(oldValue, newValue);
			ValueChanged(this, args);
		}

		#endregion

		#region Public methods

		public void Update(float updatedValue)
		{
			if (updatedValue < MinValue)
			{
				updatedValue = MinValue;
			}
			if (updatedValue > MaxValue)
			{
				updatedValue = MaxValue;
			}
			if (Value.AlmostEqual(updatedValue))
			{
				return;
			}

			var oldValue = Value;
			Value = updatedValue;

			OnValueChanged(oldValue, updatedValue);
		}

		#endregion
	}
}
