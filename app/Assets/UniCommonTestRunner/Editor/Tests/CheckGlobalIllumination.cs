using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace UniCommonTestRunner
{
	public partial class UniCommonTestRunner
	{
		/// <summary>
		/// 2D のシーンでグローバルイルミネーションが無効になっているかどうかテストします
		/// </summary>
		[Test]
		public void CheckGlobalIllumination()
		{
			var settings = UCTRUtils.GetSettings();

			Assert.IsNotNull( settings, "`UCTRSettings.asset` could not be found." );

			if ( settings == null ) return;

			var result = new List<string>();

			var scenePathList = settings
				.GetScenePathList()
				.Where( c => c.Contains( "2D" ) )
			;

			foreach ( var n in scenePathList )
			{
				var scene = EditorSceneManager.OpenScene( n );
				var isValid = !Lightmapping.realtimeGI && !Lightmapping.bakedGI;

				if ( isValid ) continue;

				result.Add( n );
			}

			if ( result.Count <= 0 ) return;

			var sb = new StringBuilder();

			foreach ( var n in result )
			{
				sb.AppendLine( n );
			}

			Assert.Fail( sb.ToString() );
		}
	}
}