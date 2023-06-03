using Stride.Rendering.Compositing;

namespace Stride.Engine;

public static class ScriptComponentExtensions
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
	/// Gets the camera from the <see cref="GraphicsCompositor"/> with the name main
	/// </summary>
	/// <param name="scriptComponent"></param>
	/// <returns></returns>
	public static CameraComponent GetCamera(this ScriptComponent scriptComponent)
	{
		SceneCameraSlotCollection cameraCollection = scriptComponent.SceneSystem.GraphicsCompositor.Cameras;
		foreach (var sceneCamera in cameraCollection)
		{
			if (sceneCamera.Name == "Main")
			{
				return sceneCamera.Camera;
			}
		}
		return null;
	}

	/// <summary>
	/// Gets the camera from the <see cref="GraphicsCompositor"/> with the given name.
	/// </summary>
	/// <param name="scriptComponent"></param>
	/// <param name="cameraName"></param>
	/// <returns></returns>
	public static CameraComponent GetCamera(this ScriptComponent scriptComponent, string cameraName)
	{
		SceneCameraSlotCollection cameraCollection = scriptComponent.SceneSystem.GraphicsCompositor.Cameras;
		foreach (var sceneCamera in cameraCollection)
		{
			if (sceneCamera.Name == cameraName)
			{
				return sceneCamera.Camera;
			}
		}
		return null;
	}

	/// <summary>
	/// Gets the first camera from the <see cref="GraphicsCompositor"/>
	/// </summary>
	/// <param name="scriptComponent"></param>
	/// <returns></returns>
	public static CameraComponent GetFirstCamera(this ScriptComponent scriptComponent)
	{
		SceneCameraSlotCollection cameraCollection = scriptComponent.SceneSystem.GraphicsCompositor.Cameras;

		return cameraCollection[0].Camera;
	}
}
