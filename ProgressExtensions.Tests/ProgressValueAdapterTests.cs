using NUnit.Framework;
using ProgressExtensions.Common;

namespace ProgressExtensions.Tests
{
	[TestFixture]
	public class ProgressValueAdapterTests
	{
		private const float InitialMin = 0f;
		private const float InitialMax = 100f;

		private const float AdapterMin = 10f;
		private const float AdapterMax = 20f;

		private ValueProgress initial;
		private ProgressValueAdapter adapter;

		[OneTimeSetUp]
		public void Init()
		{
			initial = new ValueProgress(InitialMin, InitialMax);
			adapter = new ProgressValueAdapter(initial, AdapterMin, AdapterMax);
		}

		[Test]
		public void CheckMinValue()
		{
			adapter.Update(AdapterMin);
			Assert.True(initial.Value.AlmostEqual(InitialMin));
		}

		[Test]
		public void CheckMaxValue()
		{
			adapter.Update(AdapterMax);
			Assert.True(initial.Value.AlmostEqual(InitialMax));
		}

		[Test]
		public void CheckMediumValue()
		{
			adapter.Update((AdapterMax - AdapterMin) / 2 + AdapterMin);
			Assert.True(initial.Value.AlmostEqual((InitialMax - InitialMin) / 2 + InitialMin));
		}
	}
}
