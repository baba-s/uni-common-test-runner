using NUnit.Framework;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.Animations;

namespace UniCommonTestRunner
{
	public partial class UniCommonTestRunner
	{
		/// <summary>
		/// Animator Controller のステートが null になっていないかどうかテストします
		/// </summary>
		[Test]
		public void CheckAnimatorControllerState()
		{
			var list = AssetDatabase
				.FindAssets( "t:AnimatorController" )
				.Select( AssetDatabase.GUIDToAssetPath )
				.Select( c => AssetDatabase.LoadAssetAtPath<AnimatorController>( c ) )
				.Where( c => c != null )
				.Where( c => HasNullMotion( c ) )
				.Select( c => AssetDatabase.GetAssetPath( c ) )
			;

			if ( !list.Any() ) return;

			var sb = new StringBuilder();

			foreach ( var n in list )
			{
				sb.AppendLine( n );
			}

			Assert.Fail( sb.ToString() );
		}

		private bool HasNullMotion( AnimatorController controller )
		{
			foreach ( var layer in controller.layers )
			{
				if ( layer.stateMachine.states.Any( c => c.state.motion == null ) )
				{
					return true;
				}
			}
			return false;
		}
	}
}