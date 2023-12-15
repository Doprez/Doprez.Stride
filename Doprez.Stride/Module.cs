﻿using Stride.Core;
using Stride.Core.Reflection;
using System.Reflection;

namespace Doprez.Stride;
internal class Module
{
	[ModuleInitializer]
	public static void Initialize()
	{
		AssemblyRegistry.Register(typeof(Module).GetTypeInfo().Assembly, AssemblyCommonCategories.Assets);
	}
}
