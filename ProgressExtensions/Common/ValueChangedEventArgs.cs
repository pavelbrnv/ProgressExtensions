using System;

namespace ProgressExtensions.Common
{
	public class ValueChangedEventArgs<T> : EventArgs
	{
		public T OldValue { get; }

		public T NewValue { get; }

		public ValueChangedEventArgs(T oldValue, T newValue)
		{
			OldValue = oldValue;
			NewValue = newValue;
		}
	}

	public class SingleValueChangedEventArgs : ValueChangedEventArgs<float>
	{
		public SingleValueChangedEventArgs(float oldValue, float newValue)
			: base(oldValue, newValue)
		{
		}
	}
}
