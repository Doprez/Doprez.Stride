using System;
using Stride.Engine;

namespace Stride.Engine;

public static class GameExtensions
{
	[Obsolete("Use GetFPS() instead of this.")]
	public static float FPS(this Game game)
	{
		return game.UpdateTime.FramePerSecond;
	}
	public static float GetFPS(this Game game)
	{
		return game.UpdateTime.FramePerSecond;
	}
}
