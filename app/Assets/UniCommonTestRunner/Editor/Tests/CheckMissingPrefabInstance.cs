using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// Missing Prefab になっているゲームオブジェクトが存在しないかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Missing Prefab Instance" )]
		private static void CheckMissingPrefabInstanceFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckMissingPrefabInstance", DoCheckMissingPrefabInstance );
		}

		[Test]
		public void CheckMissingPrefabInstance()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckMissingPrefabInstance );
		}

		private static bool DoCheckMissingPrefabInstance( GameObject go )
		{
			return PrefabUtility.GetPrefabInstanceStatus( go ) == PrefabInstanceStatus.MissingAsset;
		}
	}
}