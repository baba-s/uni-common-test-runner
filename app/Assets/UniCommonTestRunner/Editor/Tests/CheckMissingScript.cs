using NUnit.Framework;
using System.Linq;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// Missing Script が存在しないかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Missing Script" )]
		private static void CheckMissingScriptFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckMissingScript", DoCheckMissingScript );
		}

		[Test]
		public void CheckMissingScript()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckMissingScript );
		}

		private static bool DoCheckMissingScript( GameObject go )
		{
			return go.GetComponents<Component>().Any( com => com == null );
		}
	}
}