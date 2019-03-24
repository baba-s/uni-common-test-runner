using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UniCommonTestRunner
{
	/// <summary>
	/// EventSystem の Drag Threshold が統一されているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Event System Drag Threshold" )]
		private static void CheckEventSystemDragThresholdFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckEventSystemDragThreshold", DoCheckEventSystemDragThreshold );
		}

		[Test]
		public void CheckEventSystemDragThreshold()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckEventSystemDragThreshold );
		}

		private static bool DoCheckEventSystemDragThreshold( GameObject go )
		{
			var eventSystem = go.GetComponent<EventSystem>();
			if ( eventSystem == null ) return false;
			if ( eventSystem.pixelDragThreshold == 25 ) return false;
			return true;
		}
	}
}