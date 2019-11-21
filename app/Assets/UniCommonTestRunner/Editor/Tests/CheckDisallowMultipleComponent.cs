using NUnit.Framework;
using System.Linq;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// DisallowMultipleComponent が適用されているコンポーネントが複数アタッチされていないかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Disallow Multiple Component" )]
		private static void CheckDisallowMultipleComponentFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckDisallowMultipleComponent", DoCheckDisallowMultipleComponent );
		}

		[Test]
		public void CheckDisallowMultipleComponent()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckDisallowMultipleComponent );
		}

		private static bool DoCheckDisallowMultipleComponent( GameObject go )
		{
			var components = go.GetComponents<Component>();

			foreach ( var component in components )
			{
				if ( component == null ) return true;

				var type = component.GetType();
				var attrs = type.GetCustomAttributes( typeof( DisallowMultipleComponent ), true );

				if ( attrs == null || attrs.Length <= 0 ) continue;

				var count = components.Count( c => c.GetType() == type );

				if ( count <= 1 ) continue;

				return true;
			}

			return false;
		}
	}
}