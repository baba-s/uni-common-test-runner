using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UniCommonTestRunner
{
	/// <summary>
	/// Canvas Scaler のパラメータが正しいかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		private const CanvasScaler.ScaleMode UI_SCALE_MODE = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		private const int REFERENCE_RESOLUTION_X = 1024;
		private const int REFERENCE_RESOLUTION_Y = 576;
		private const CanvasScaler.ScreenMatchMode SCREEN_MATCH_MODE = CanvasScaler.ScreenMatchMode.Expand;

		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Canvas Scaler" )]
		private static void CheckCanvasScalerFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckCanvasScaler", DoCheckCanvasScaler );
		}

		[Test]
		public void CheckCanvasScaler()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckCanvasScaler );
		}

		private static bool DoCheckCanvasScaler( GameObject go )
		{
			var scaler = go.GetComponent<CanvasScaler>();
			if ( scaler == null ) return false;
			if ( scaler.uiScaleMode != UI_SCALE_MODE ) return true;
			if ( scaler.referenceResolution.x != REFERENCE_RESOLUTION_X ) return true;
			if ( scaler.referenceResolution.y != REFERENCE_RESOLUTION_Y ) return true;
			if ( scaler.screenMatchMode != SCREEN_MATCH_MODE ) return true;
			return false;
		}
	}
}