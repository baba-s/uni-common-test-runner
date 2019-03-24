using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// RectTransform の Position が整数になっているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check RectTransform Position Floating Point" )]
		private static void CheckRectTransformPositionFloatingPointFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckRectTransformPositionFloatingPoint", DoCheckRectTransformPositionFloatingPoint );
		}

		[Test]
		public void CheckRectTransformPositionFloatingPoint()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckRectTransformPositionFloatingPoint );
		}

		private static bool DoCheckRectTransformPositionFloatingPoint( GameObject go )
		{
			var rectTransform = go.GetComponent<RectTransform>();
			if ( rectTransform == null ) return false;
			var localPosition = rectTransform.localPosition;
			return
				localPosition.x.HasBelowFloatingPoint() ||
				localPosition.y.HasBelowFloatingPoint() ||
				localPosition.z.HasBelowFloatingPoint()
			;
		}
	}
}