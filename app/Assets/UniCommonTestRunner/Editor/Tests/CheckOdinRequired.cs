using NUnit.Framework;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UniCommonTestRunner.Internal;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace UniCommonTestRunner
{
	/// <summary>
	/// Odin の Required 属性が適用されている変数に参照が設定されているかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
#if ODIN_INSPECTOR

		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Odin Required" )]
		private static void CheckOdinRequiredFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckOdinRequired", DoCheckOdinRequired );
		}

		[Test]
		public void CheckOdinRequired()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckOdinRequired );
		}

		private static bool DoCheckOdinRequired( GameObject go )
		{
			var components = go.GetComponents<Component>();

			foreach ( var component in components )
			{
				var type = component.GetType();
				var fields = type.GetFields( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance );

				foreach ( var field in fields )
				{
					var attrs = field.GetCustomAttributes( typeof( RequiredAttribute ), true );

					if ( attrs == null || attrs.Length <= 0 ) continue;

					var value = field.GetValue( component );
		
					if ( value != null && value.ToString() != "null" ) continue;

					return true;
				}
			}

			return false;
		}

#endif
	}
}