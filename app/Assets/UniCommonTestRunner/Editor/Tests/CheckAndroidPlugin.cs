using NUnit.Framework;
using System.Linq;
using System.Text;
using UnityEditor;

namespace UniCommonTestRunner
{
	public partial class UniCommonTestRunner
	{
		/// <summary>
		/// Android 用のプラグインのプラットフォームが適切に設定されているかどうかテストします
		/// </summary>
		[Test]
		public void CheckAndroidPlugin()
		{
			var list = AssetDatabase
				.GetAllAssetPaths()
				.Where( c => c.Contains( "Plugins" ) )
				.Where( c => c.Contains( "Android" ) )
				.Select( c => AssetImporter.GetAtPath( c ) )
				.OfType<PluginImporter>()
				.Where( c => c != null )
				.Where( c => c.GetCompatibleWithPlatform( BuildTarget.iOS ) )
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
	}
}