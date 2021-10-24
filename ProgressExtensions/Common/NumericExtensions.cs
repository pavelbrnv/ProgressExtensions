using System;

namespace ProgressExtensions.Common
{
	public static class NumericExtensions
	{
		public const float FloatDefaultPrecision = 0.00001f;
		
		public static bool AlmostEqual(this float a, float b)
		{
			return AlmostEqual(a, b, FloatDefaultPrecision);
		}

		public static bool AlmostEqual(this float a, float b, float precision)
		{
			return Math.Abs(a - b) < precision;
		}
	}
}
