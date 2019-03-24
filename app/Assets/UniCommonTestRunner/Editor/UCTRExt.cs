using UnityEngine;

namespace UniCommonTestRunner.Internal
{
	/// <summary>
	/// 拡張メソッドを管理するクラス
	/// </summary>
	public static class UCTRExt
	{
		/// <summary>
		/// 指定されたゲームオブジェクトのルートパスを返します
		/// </summary>
		public static string GetRootPath( this GameObject gameObject )
		{
			var path = gameObject.name;
			var parent = gameObject.transform.parent;

			while ( parent != null )
			{
				path = parent.name + "/" + path;
				parent = parent.parent;
			}

			return path;
		}

		/// <summary>
		/// 浮動小数点以下を含む場合 true を返します
		/// </summary>
		public static bool HasBelowFloatingPoint( this float self )
		{
			return self % 1 != 0;
		}
	}
}