using NUnit.Framework;
using UnityEditor;

namespace UniCommonTestRunner
{
	public partial class UniCommonTestRunner
	{
		/// <summary>
		/// 加速度センサーが無効になっているかどうかテストします
		/// </summary>
		[Test]
		public void CheckAccelerometerFrequency()
		{
			Assert.IsTrue( PlayerSettings.accelerometerFrequency == 0 );
		}
	}
}