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
}
