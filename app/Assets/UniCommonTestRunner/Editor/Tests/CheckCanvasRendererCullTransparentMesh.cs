using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UniCommonTestRunner
{
	/// <summary>
	/// 透明な UI オブジェクトの Cull Transparent Mesh がオンになっているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Canvas Renderer Cull Transparent Mesh" )]
		private static void CheckCanvasRendererCullTransparentMeshFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckCanvasRendererCullTransparentMesh", DoCheckCanvasRendererCullTransparentMesh );
		}

		[Test]
		public void CheckCanvasRendererCullTransparentMesh()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckCanvasRendererCullTransparentMesh );
		}

		private static bool DoCheckCanvasRendererCullTransparentMesh( GameObject go )
		{
			var graphic = go.GetComponent<Graphic>();
			if ( graphic == null ) return false;
			var canvasRenderer = go.GetComponent<CanvasRenderer>();
			if ( canvasRenderer == null ) return false;
			var mask = go.GetComponent<Mask>();
			if ( mask != null ) return false;
			return graphic.color.a <= 0 && !canvasRenderer.cullTransparentMesh;
		}
	}
}