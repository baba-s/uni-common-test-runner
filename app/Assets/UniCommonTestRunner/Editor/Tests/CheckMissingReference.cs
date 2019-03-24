using NUnit.Framework;
using System.Linq;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// Missing になっている参照が存在しないかどうかテストします
	/// </summary>
	public partial class UniCommonTestRunner
	{
		[MenuItem( UCTRConst.MENU_ITEM_ROOT + "Check Missing Reference" )]
		private static void CheckMissingReferenceFromMenu()
		{
			UCTRUtils.CheckGameObjectsInCurrentScene( "CheckMissingReference", DoCheckMissingReference );
		}

		[Test]
		public void CheckMissingReference()
		{
			UCTRUtils.CheckGameObjectsAll( DoCheckMissingReference );
		}

		private static bool DoCheckMissingReference( GameObject go )
		{
			var components = go
				.GetComponents<Component>()
				.Where( c => c != null )
			;

			foreach ( var c in components )
			{
				var so = new SerializedObject( c );
				var sp = so.GetIterator();

				while ( sp.NextVisible( true ) )
				{
					if ( sp.propertyType != SerializedPropertyType.ObjectReference ) continue;
					if ( sp.objectReferenceValue != null ) continue;
					if ( !sp.hasChildren ) continue;
					var fileId = sp.FindPropertyRelative( "m_FileID" );
					if ( fileId == null ) continue;
					if ( fileId.intValue == 0 ) continue;

					return true;
				}
			}

			return false;
		}
	}
}