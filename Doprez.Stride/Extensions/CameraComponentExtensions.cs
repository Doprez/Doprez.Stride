
using Stride.Core.Mathematics;

namespace Stride.Engine;
public static class CameraComponentExtensions
{
	public static Vector3 LogicDirectionToWorldDirection(this CameraComponent camera, Vector2 logicDirection, Vector3 upVector)
	{
		camera.Update();
		var inverseView = Matrix.Invert(camera.ViewMatrix);

		var forward = Vector3.Cross(upVector, inverseView.Right);
		forward.Normalize();

		var right = Vector3.Cross(forward, upVector);
		var worldDirection = forward * logicDirection.Y + right * logicDirection.X;
		worldDirection.Normalize();
		return worldDirection;
	}

	public static Vector3 LogicDirectionToWorldDirection(this CameraComponent camera, Vector2 logicDirection)
	{
		camera.Update();
		var upVector = Vector3.UnitY;
		var inverseView = Matrix.Invert(camera.ViewMatrix);

		var forward = Vector3.Cross(upVector, inverseView.Right);
		forward.Normalize();

		var right = Vector3.Cross(forward, upVector);
		var worldDirection = forward * logicDirection.Y + right * logicDirection.X;
		worldDirection.Normalize();
		return worldDirection;
	}
}
