using Stride.Engine;

namespace Stride.Engine;

public static class ModelComponentExtensions
{
	/// <summary>
	/// Gets the ModelComponents BoundingBox and calculates the Y height
	/// </summary>
	/// <param name="modelComponent"></param>
	/// <returns></returns>
	public static float GetMeshHeight(this ModelComponent modelComponent)
	{
		var boundingBox = modelComponent.Model.BoundingBox;
		var height = boundingBox.Maximum.Y - boundingBox.Minimum.Y;
		return height;
	}
}
