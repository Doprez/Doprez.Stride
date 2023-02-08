using Stride.Engine;

namespace Stride.Engine;

public static class ModelComponentExtensions
{
	public static float GetMeshHeight(this ModelComponent modelComponent)
	{
		var boundingBox = modelComponent.Model.BoundingBox;
		var height = boundingBox.Maximum.Y - boundingBox.Minimum.Y;
		return height;
	}
}
