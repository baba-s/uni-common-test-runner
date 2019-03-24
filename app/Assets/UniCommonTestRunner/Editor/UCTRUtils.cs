using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniCommonTestRunner.Internal;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UniCommonTestRunner
{
	/// <summary>
	/// シーンやプレハブに存在するゲームオブジェクトを参照するためのクラス
	/// </summary>
	public static class UCTRUtils
	{
		//==============================================================================
		// クラス
		//==============================================================================
		/// <summary>
		/// ゲームオブジェクトの情報を管理するクラス
		/// </summary>
		public sealed class GameObjectData
		{
			//==========================================================================
			// プロパティ
			//==========================================================================
			public string ScenePath { get; private set; }
			public string RootPath { get; private set; }

			//==========================================================================
			// 関数
			//==========================================================================
			public GameObjectData( string scenePath, GameObject gameObject )
			{
				ScenePath = scenePath;
				RootPath = gameObject.GetRootPath();
			}
		}

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 現在のシーンに所属するゲームオブジェクトに対してテストを行います
		/// </summary>
		public static void CheckGameObjectsInCurrentScene( string name, Func<GameObject, bool> predicate )
		{
			var gameObjectList = GetGameObjectsInCurrentScene( predicate ).ToArray();

			if ( !gameObjectList.Any() )
			{
				Debug.Log( $"[{name}] Success!" );
				return;
			}

			var result = gameObjectList.OrderByName();

			var sb = new StringBuilder();
			sb.AppendLine( $"[{name}] Failure" );
			sb.AppendLine();

			foreach ( var n in result )
			{
				sb.AppendLine( $"- {n.RootPath}" );
			}

			Debug.LogError( sb.ToString() );
		}

		/// <summary>
		/// すべてのシーンやすべてのプレハブに所属するゲームオブジェクトに対してテストを行います
		/// </summary>
		public static void CheckGameObjectsAll( Func<GameObject, bool> predicate )
		{
			var settings = GetSettings();

			Assert.IsNotNull( settings, "`UniCommonTestRunnerSettings.asset` could not be found." );

			if ( settings == null ) return;

			var result = new List<GameObjectData>();

			foreach ( var n in settings.GetScenePathList() )
			{
				var scene = EditorSceneManager.OpenScene( n );
				var gameObjectList = GetGameObjectsInCurrentScene( predicate );

				result.AddRange( gameObjectList );
			}

			result.AddRange( GetGameObjectsInAllPrefab( predicate ) );

			if ( result.Count <= 0 ) return;

			var output = result
				.OrderByName()
				.GroupBy( c => c.ScenePath )
			;

			var sb = new StringBuilder();

			foreach ( var n in output )
			{
				sb.AppendLine( $"# {n.Key}" );
				sb.AppendLine();

				foreach ( var data in n )
				{
					sb.AppendLine( $"- {data.RootPath}" );
				}

				sb.AppendLine();
			}

			Assert.Fail( sb.ToString() );
		}

		/// <summary>
		/// 設定ファイルを返します
		/// </summary>
		public static UCTRSettings GetSettings()
		{
			var settings = AssetDatabase
				.FindAssets( "t:UCTRSettings" )
				.Select( c => AssetDatabase.GUIDToAssetPath( c ) )
				.Select( c => AssetDatabase.LoadAssetAtPath<UCTRSettings>( c ) )
				.Where( c => c != null )
				.FirstOrDefault()
			;

			return settings;
		}

		/// <summary>
		/// 現在のシーンからすべてのゲームオブジェクトを取得して返します
		/// </summary>
		private static IEnumerable<GameObjectData> GetGameObjectsInCurrentScene( Func<GameObject, bool> predicate )
		{
			var list = Resources
				.FindObjectsOfTypeAll<GameObject>()
				.Where( c => c.scene.isLoaded )
				.Where( c => c.hideFlags == HideFlags.None )
				.Where( predicate )
				.Select( c => new GameObjectData( c.scene.path, c ) )
			;

			foreach ( var n in list )
			{
				yield return n;
			}
		}

		/// <summary>
		/// すべてのプレハブからすべてのゲームオブジェクトを取得して返します
		/// </summary>
		private static IEnumerable<GameObjectData> GetGameObjectsInAllPrefab( Func<GameObject, bool> predicate )
		{
			var list = AssetDatabase
				.FindAssets( "t:Prefab" )
				.Select( AssetDatabase.GUIDToAssetPath )
				.Select( c => AssetDatabase.LoadAssetAtPath<GameObject>( c ) )
				.Where( c => c != null )
				.Where( c => c.name != "DataPrivacyButton" )
				.SelectMany( c => c.GetComponentsInChildren<Transform>( true ) )
				.Select( c => c.gameObject )
				.Where( predicate )
				.Select( c => new GameObjectData( AssetDatabase.GetAssetPath( c ), c ) )
			;

			foreach ( var n in list )
			{
				yield return n;
			}
		}

		/// <summary>
		/// シーンのパスやルートパスをもとに並べ替えます
		/// </summary>
		private static IEnumerable<GameObjectData> OrderByName( this IEnumerable<GameObjectData> self )
		{
			return self
				.OrderBy( c => c.ScenePath )
				.ThenBy( c => c.RootPath )
			;
		}
	}
}