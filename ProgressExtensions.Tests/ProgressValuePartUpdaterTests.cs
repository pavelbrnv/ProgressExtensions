using NUnit.Framework;
using ProgressExtensions.Common;

namespace ProgressExtensions.Tests
{
	[TestFixture]
	public class ProgressValuePartUpdaterTests
	{
		private const float InitialMin = 0f;
		private const float InitialMax = 100f;

		private const float PartMin = 10f;
		private const float PartMax = 20f;

		private ValueProgress initial;
		private ProgressValuePartUpdater partUpdater;

		[OneTimeSetUp]
		public void Init()
		{
			initial = new ValueProgress(InitialMin, InitialMax);
			partUpdater = new ProgressValuePartUpdater(initial, PartMin, PartMax);
		}

		[Test]
		public void CheckPartResetting()
		{
			partUpdater.Reset();
			Assert.True(initial.Value.AlmostEqual(PartMin));
		}

		[Test]
		public void CheckPartSettingFull()
		{
			partUpdater.SetFull();
			Assert.True(initial.Value.AlmostEqual(PartMax));
		}
	}
}
