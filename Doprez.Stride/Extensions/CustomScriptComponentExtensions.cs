using Stride.Engine;
using Stride.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doprez.Stride.Extensions
{
	public static class CustomScriptComponentExtensions
	{
		/// <summary>
		/// Returns delta time in a shorter format.
		/// </summary>
		/// <param name="scriptComponent"></param>
		/// <returns></returns>
		public static float DeltaTime(this ScriptComponent scriptComponent)
		{
			return (float)scriptComponent.Game.UpdateTime.Elapsed.TotalSeconds;
		}
	}
}
