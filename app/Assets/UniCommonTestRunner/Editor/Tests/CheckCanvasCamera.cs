using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// Canvas にカメラが設定されているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Canvas Camera" )]
		private static void CheckCanvasCameraFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckCanvasCamera", DoCheckCanvasCamera );
		}

		[Test]
		public void CheckCanvasCamera()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckCanvasCamera );
		}

		private static bool DoCheckCanvasCamera( GameObject go )
		{
			var canvas = go.GetComponent<Canvas>();
			if ( canvas == null ) return false;
			var so = new SerializedObject( canvas );
			var renderMode = so.FindProperty( "m_RenderMode" );
			if ( renderMode.intValue == 0 ) return false;
			var camera = so.FindProperty( "m_Camera" );
			var fileId = camera.FindPropertyRelative( "m_FileID" );
			if ( fileId == null || fileId.intValue != 0 ) return false;
			return true;
		}
	}
}