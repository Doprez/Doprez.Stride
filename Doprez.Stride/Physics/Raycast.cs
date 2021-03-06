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
        public IInteractable GetInteractableWithRayCast(Entity entityPosition)
        {
            Vector3 startPosition = new Vector3();
            Quaternion rotation = new Quaternion();
            Vector3 scale = new Vector3();
            entityPosition.Transform.GetWorldTransformation(out startPosition, out rotation, out scale);

            var targetPosition = Vector3.Transform(startPosition + new Vector3(0, 0, -3f), rotation);

            IInteractable result = null;

            if (_simulation.Raycast(startPosition, targetPosition, out HitResult _hitresult, CollisionFilterGroups.DefaultFilter, CollideWith))
            {
                result = _hitresult.Collider.Entity.GetComponent<IInteractable>();
            }

            return result;
        }
    }
}
