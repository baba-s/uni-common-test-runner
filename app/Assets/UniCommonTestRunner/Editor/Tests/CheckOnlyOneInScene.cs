using NUnit.Framework;
using System.Linq;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// OnlyOneInSceneAttribute が適用されているコンポーネントがシーンに 1つだけかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Only One In Scene" )]
		private static void CheckOnlyOneInSceneFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckOnlyOneInScene", DoCheckOnlyOneInScene );
		}

		[Test]
		public void CheckOnlyOneInScene()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckOnlyOneInScene );
		}

		private static bool DoCheckOnlyOneInScene( GameObject go )
		{
			var components = go.GetComponents<Component>();

			foreach ( var component in components )
			{
				var type = component.GetType();
				var attrs = type.GetCustomAttributes( typeof( OnlyOneInSceneAttribute ), true );

				if ( attrs == null || attrs.Length <= 0 ) continue;

				var count = Resources
					.FindObjectsOfTypeAll<GameObject>()
					.Where( c => c.scene.isLoaded )
					.Where( c => c.hideFlags == HideFlags.None )
					.SelectMany( c => c.GetComponents( type ) )
					.Where( c => c != null )
					.Count()
				;

				if ( count <= 1 ) continue;

				return true;
			}

			return false;
		}
	}
}