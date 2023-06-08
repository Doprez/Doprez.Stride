using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;

namespace Doprez.Stride.Utils;

[DataContract("DoprezSmoothRotate")]
[ComponentCategory("Utils")]
public class SmoothRotate : SyncScript
{
	public Entity EntityToFollow { get; set; }
	public float Speed { get; set; } = 1;

	public override void Update()
	{
		var currentRotation = Entity.Transform.Rotation;
		EntityToFollow.Transform.GetWorldTransformation(out var _, out var otherRotation, out var _);

		Quaternion.Slerp(ref currentRotation, ref otherRotation, Speed * this.DeltaTime(), out var newRotation);

		Entity.Transform.Rotation = newRotation;
	}
}
