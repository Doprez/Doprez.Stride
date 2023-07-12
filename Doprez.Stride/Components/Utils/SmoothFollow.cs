using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;

namespace Doprez.Stride.Utils;

[DataContract("DoprezSmoothFollow")]
[ComponentCategory("Utils")]
public class SmoothFollow : SyncScript
{
	public Entity EntityToFollow { get; set; }
	public Vector3 Speed { get; set; } = new Vector3(1, 1, 1);

	public override void Update()
	{
		var currentPosition = Entity.Transform.Position;
		var otherPosition = EntityToFollow.WorldPosition();
		var x = MathUtil.Lerp(currentPosition.X, otherPosition.X, Speed.X * this.DeltaTime());
		var y = MathUtil.Lerp(currentPosition.Y, otherPosition.Y, Speed.Y * this.DeltaTime());
		var z = MathUtil.Lerp(currentPosition.Z, otherPosition.Z, Speed.Z * this.DeltaTime());
		Entity.Transform.Position = new Vector3(x, y, z);
	}
}
