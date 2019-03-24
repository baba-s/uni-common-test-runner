using NUnit.Framework;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// Audio Listener が存在しないかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Audio Listener Exist" )]
		private static void CheckAudioListenerExistFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckAudioListenerExist", DoCheckAudioListenerExist );
		}

		[Test]
		public void CheckAudioListenerExist()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckAudioListenerExist );
		}

		private static bool DoCheckAudioListenerExist( GameObject go )
		{
			return go.GetComponent<AudioListener>();
		}
	}
}