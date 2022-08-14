using Doprez.Stride.Extensions;
using Doprez.Stride.Interfaces;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doprez.Stride.Physics
{
    [ComponentCategory("Physics")]
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
		/// return true if Raycast hit and outputs a HitResult
		/// </summary>
		/// <param name="entityPosition"></param>
		/// <returns>IInteractable if found or null if not found</returns>
		[Obsolete("Please use the Raycast method instead. This method fails in negative quadrants of a scene")]
		public bool FireRayCast(Entity entityPosition, out HitResult hitResult, float rayDistance)
        {
            Vector3 startPosition = new Vector3();
            Quaternion rotation = new Quaternion();
            Vector3 scale = new Vector3();
            entityPosition.Transform.GetWorldTransformation(out startPosition, out rotation, out scale);

            var targetPosition = Vector3.Transform(startPosition + new Vector3(0, 0, -rayDistance), rotation);

            if (_simulation.Raycast(startPosition, targetPosition, out HitResult hitresultvalue, CollisionFilterGroups.DefaultFilter, CollideWith))
            {
                hitResult = hitresultvalue;
                return true;
            }
            hitResult = new HitResult();
            return false;
        }

        /// <summary>
        /// Retrieves an attached IInteractable if it exists on the Entity
        /// </summary>
        /// <param name="entityPosition"></param>
        /// <returns>IInteractable if found or null if not found</returns>
        [Obsolete("Please use the Raycast method instead. This method fails in negative quadrants of a scene")]
        public IInteractable GetInteractableWithRayCast(Entity entityPosition)
        {
            Vector3 startPosition = new Vector3();
            Quaternion rotation = new Quaternion();
            Vector3 scale = new Vector3();
            entityPosition.Transform.GetWorldTransformation(out startPosition, out rotation, out scale);

            var targetPosition = entityPosition.Transform.Position;

            IInteractable result = null;

            if (_simulation.Raycast(startPosition, targetPosition, out HitResult _hitresult, CollisionFilterGroups.DefaultFilter, CollideWith))
            {
                result = _hitresult.Collider.Entity.GetComponent<IInteractable>();
            }

            return result;
        }

		/// <summary>
        /// A Raycast method based on the example in the fps demo
        /// Make sure you are using the actual rotating Entity otherwise you will waste hours like I did debuging a non issue
		/// </summary>
		public HitResult RayCast(Entity entityPosition)
		{
			var raycastStart = entityPosition.Transform.WorldMatrix.TranslationVector;
			var forward = entityPosition.Transform.WorldMatrix.Forward;
			var raycastEnd = raycastStart + forward * RaycastRange;

			var result = this.GetSimulation().Raycast(raycastStart, raycastEnd);

            return result;
		}

		/// <summary>
		/// An async Raycast method based on the example in the fps demo
		/// </summary>
		public async Task<HitResult> RayCastAsync(Entity entityPosition)
		{
			var raycastStart = entityPosition.Transform.WorldMatrix.TranslationVector;
			var forward = entityPosition.Transform.WorldMatrix.Forward;
			var raycastEnd = raycastStart + forward * RaycastRange;

			var result = await Task.FromResult(this.GetSimulation().Raycast(raycastStart, raycastEnd));

			return result;
		}

	}
}
