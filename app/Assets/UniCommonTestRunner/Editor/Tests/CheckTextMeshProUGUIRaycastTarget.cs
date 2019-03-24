using NUnit.Framework;
using TMPro;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// TextMeshProUGUI の Raycast Target がオフになっているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check TextMeshProUGUI Raycast Target" )]
		private static void CheckTextMeshProUGUIRaycastTargetFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckTextMeshProUGUIRaycastTarget", DoCheckTextMeshProUGUIRaycastTarget );
		}

		[Test]
		public void CheckTextMeshProUGUIRaycastTarget()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckTextMeshProUGUIRaycastTarget );
		}

		private static bool DoCheckTextMeshProUGUIRaycastTarget( GameObject go )
		{
			var textMeshProUGUI = go.GetComponent<TextMeshProUGUI>();
			return textMeshProUGUI != null && textMeshProUGUI.raycastTarget;
		}
	}
}