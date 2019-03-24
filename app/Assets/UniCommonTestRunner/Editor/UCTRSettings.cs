using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// UniCommonTestRunner の設定を管理するクラス
	/// </summary>
	public sealed class UCTRSettings : ScriptableObject
	{
		//==============================================================================
		// 列挙型
		//==============================================================================
		/// <summary>
		/// テスト対象のシーンの種類
		/// </summary>
		private enum ScenesType
		{
			ALL,
			SCENES_IN_BUILD,
			DIRECTORY_LIST,
		}

		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private ScenesType m_scenesType = ScenesType.ALL;
		[SerializeField] private string[] m_directoryList = null;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// テスト対象のすべてのシーンのパスを返します
		/// </summary>
		public IEnumerable<string> GetScenePathList()
		{
			switch ( m_scenesType )
			{
				case ScenesType.ALL:
					{
						var list = AssetDatabase
							.FindAssets( "t:scene" )
							.Select( AssetDatabase.GUIDToAssetPath )
						;

						foreach ( var n in list )
						{
							yield return n;
						}

						yield break;
					}

				case ScenesType.SCENES_IN_BUILD:
					{
						var list = EditorBuildSettings.scenes
							.Select( c => c.path )
							.Where( c => !string.IsNullOrWhiteSpace( c ) )
						;

						foreach ( var n in list )
						{
							yield return n;
						}

						yield break;
					}

				case ScenesType.DIRECTORY_LIST:
					{
						var list = AssetDatabase
							.FindAssets( "t:scene" )
							.Select( AssetDatabase.GUIDToAssetPath )
							.Where( c => m_directoryList.Any( dir => c.StartsWith( dir ) ) )
						;

						foreach ( var n in list )
						{
							yield return n;
						}

						yield break;
					}
			}

			yield break;
		}
	}
}