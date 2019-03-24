using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UniCommonTestRunner
{
	public partial class UniCommonTestRunner
	{
		/// <summary>
		/// 2D のシーンで Skybox Material が設定されていないかどうかテストします
		/// </summary>
		[Test]
		public void CheckSkyboxMaterial()
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
				var isValid = RenderSettings.skybox == null;

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