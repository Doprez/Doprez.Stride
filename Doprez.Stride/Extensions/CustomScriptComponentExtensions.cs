using System.Runtime.CompilerServices;

namespace Stride.Engine;

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

	/// <summary>
	/// Returns the current FPS.
	/// </summary>
	/// <param name="scriptComponent"></param>
	/// <returns></returns>
	public static float Fps(this ScriptComponent scriptComponent)
	{
		return scriptComponent.Game.UpdateTime.FramePerSecond;
	}

	/// <summary>
	/// Returns update time
	/// </summary>
	/// <param name="scriptComponent"></param>
	/// <returns></returns>
	public static float UpdateTime(this ScriptComponent scriptComponent)
	{
		return (float)scriptComponent.Game.UpdateTime.Elapsed.TotalSeconds;
	}


	/// <summary>
	/// Returns draw time
	/// </summary>
	/// <param name="scriptComponent"></param>
	/// <returns></returns>
	public static float DrawTime(this ScriptComponent scriptComponent)
	{
		return (float)scriptComponent.Game.DrawTime.Elapsed.TotalSeconds;
	}

}
