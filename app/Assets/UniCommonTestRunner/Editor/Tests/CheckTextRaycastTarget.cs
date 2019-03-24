using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UniCommonTestRunner
{
	/// <summary>
	/// UI.Text の Raycast Target がオフになっているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Text Raycast Target" )]
		private static void CheckTextRaycastTargetFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckTextRaycastTarget", DoCheckTextRaycastTarget );
		}

		[Test]
		public void CheckTextRaycastTarget()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckTextRaycastTarget );
		}

		private static bool DoCheckTextRaycastTarget( GameObject go )
		{
			var text = go.GetComponent<Text>();
			return text != null && text.raycastTarget;
		}
	}
}