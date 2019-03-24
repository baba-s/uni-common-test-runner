using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// RectTransform の Scale が整数になっているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check RectTransform Scale Floating Point" )]
		private static void CheckRectTransformScaleFloatingPointFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckRectTransformScaleFloatingPoint", DoCheckRectTransformScaleFloatingPoint );
		}

		[Test]
		public void CheckRectTransformScaleFloatingPoint()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckRectTransformScaleFloatingPoint );
		}

		private static bool DoCheckRectTransformScaleFloatingPoint( GameObject go )
		{
			var rectTransform = go.GetComponent<RectTransform>();
			if ( rectTransform == null ) return false;
			var localScale = rectTransform.localScale;
			return
				localScale.x.HasBelowFloatingPoint() ||
				localScale.y.HasBelowFloatingPoint() ||
				localScale.z.HasBelowFloatingPoint()
			;
		}
	}
}