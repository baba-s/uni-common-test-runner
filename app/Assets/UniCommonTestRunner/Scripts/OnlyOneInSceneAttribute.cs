using System;

namespace UniCommonTestRunner
{
	/// <summary>
	/// シーン内に 1 つだけ存在することを許容する属性
	/// </summary>
	[AttributeUsage( AttributeTargets.Class )]
	public sealed class OnlyOneInSceneAttribute : Attribute
	{
	}
}