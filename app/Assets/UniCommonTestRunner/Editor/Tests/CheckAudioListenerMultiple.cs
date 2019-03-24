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
		/// Audio Listener が複数存在しないかどうかテストします
		/// </summary>
		[Test]
		public void CheckAudioListenerMultiple()
		{
			var settings = UCTRUtils.GetSettings();

			Assert.IsNotNull( settings, "`UCTRSettings.asset` could not be found." );

			if ( settings == null ) return;

			var result = new List<string>();

			foreach ( var n in settings.GetScenePathList() )
			{
				var scene = EditorSceneManager.OpenScene( n );
				var count = Resources
					.FindObjectsOfTypeAll<GameObject>()
					.Where( c => c.scene.isLoaded )
					.Where( c => c.hideFlags == HideFlags.None )
					.Count( c => c.GetComponent<AudioListener>() != null )
				;

				if ( count <= 1 ) continue;

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