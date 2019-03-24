using NUnit.Framework;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	public partial class UniCommonTestRunner
	{
		/// <summary>
		/// モバイル用のシェーダがマテリアルに設定されているかどうかテストします
		/// </summary>
		[Test]
		public void CheckMaterialShader()
		{
			var targets = new []
			{
				"Legacy Shaders/Bumped Diffuse",
				"Legacy Shaders/Bumped Specular",
				"Legacy Shaders/Diffuse",
				"Legacy Shaders/Particles/Additive",
				"Legacy Shaders/Particles/Additive (Soft)",
				"Legacy Shaders/Particles/Alpha Blended",
				"Legacy Shaders/Particles/Multiply",
				"Legacy Shaders/Particles/VertexLit Blended",
				"Particles/Standard Surface",
				"Particles/Standard Unlit",
			};

			var list = AssetDatabase
				.FindAssets( "t:Material" )
				.Select( AssetDatabase.GUIDToAssetPath )
				.Select( c => AssetDatabase.LoadAssetAtPath<Material>( c ) )
				.Where( c => c != null )
				.Where( c => targets.Any( target => target == c.shader.name ) )
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