using Stride.Core;
using Stride.Engine;
using Stride.Physics;
using System.Threading.Tasks;

namespace Doprez.Stride.Physics
{
    [ComponentCategory("Physics")]
	[DataContract("DoprezRaycast")]
    public class Raycast : StartupScript
    {
        public CollisionFilterGroupFlags CollideWith;
        public float RaycastRange { get; set; } = 1;

        private Simulation _simulation;

        public override void Start()
        {
            _simulation = this.GetSimulation();
        }

		/// <summary>
		/// A Raycast method based on the example in the fps demo
		/// <para>Make sure you are using the actual rotating Entity otherwise you will waste hours like I did debuging a non issue</para>
		/// </summary>
		public HitResult RayCast(Entity entityPosition)
		{
			var raycastStart = entityPosition.Transform.WorldMatrix.TranslationVector;
			var forward = entityPosition.Transform.WorldMatrix.Forward;
			var raycastEnd = raycastStart + (forward * RaycastRange);

			var result = _simulation.Raycast(raycastStart, raycastEnd);

            return result;
		}

		/// <summary>
		/// An async Raycast method based on the example in the fps demo
		/// <para>Make sure you are using the actual rotating Entity otherwise you will waste hours like I did debuging a non issue</para>
		/// </summary>
		public async Task<HitResult> RayCastAsync(Entity entityPosition)
		{
			var raycastStart = entityPosition.Transform.WorldMatrix.TranslationVector;
			var forward = entityPosition.Transform.WorldMatrix.Forward;
			var raycastEnd = raycastStart + (forward * RaycastRange);

			var result = await Task.FromResult(_simulation.Raycast(raycastStart, raycastEnd));

			return result;
		}
	}
}
