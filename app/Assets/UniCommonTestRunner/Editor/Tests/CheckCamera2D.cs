using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// 2D のカメラのパタメータが正しく設定されているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Camera 2D" )]
		private static void CheckCamera2DFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckCamera2D", DoCheckCamera2D );
		}

		[Test]
		public void CheckCamera2D()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckCamera2D );
		}

		private static bool DoCheckCamera2D( GameObject go )
		{
			var camera = go.GetComponent<Camera>();
			if ( camera == null ) return false;
			if ( camera.clearFlags != CameraClearFlags.Color ) return true;
			if ( !camera.orthographic ) return true;
			if ( camera.orthographicSize != 5 ) return true;
			if ( camera.useOcclusionCulling ) return true;
			return false;
		}
	}
}