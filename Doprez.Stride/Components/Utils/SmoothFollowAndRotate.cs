using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;

namespace Doprez.Stride.Utils;

[ComponentCategory("Utils")]
[DataContract("DoprezSmoothFollowAndRotate")]
public class SmoothFollowAndRotate : SyncScript
{
	public Entity EntityToFollow { get; set; }
	public float Speed { get; set; } = 1;

	public override void Update()
	{
		var currentPosition = Entity.Transform.Position;
		var currentRotation = Entity.Transform.Rotation;

		EntityToFollow.Transform.GetWorldTransformation(out var otherPosition, out var otherRotation, out var _);

		var newPosition = Vector3.Lerp(currentPosition, otherPosition, Speed * this.DeltaTime());
		Entity.Transform.Position = newPosition;

		Quaternion.Slerp(ref currentRotation, ref otherRotation, Speed * this.DeltaTime(), out var newRotation);
		Entity.Transform.Rotation = newRotation;
	}
}
