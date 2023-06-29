using Stride.Engine;

namespace Stride.Engine;

public static class GameExtensions
{
	public static float FPS(this Game game)
	{
		return game.UpdateTime.FramePerSecond;
	}
}
