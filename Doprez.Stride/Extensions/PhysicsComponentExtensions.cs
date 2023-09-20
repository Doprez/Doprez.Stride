using Stride.Engine;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Stride.Engine;
public static class PhysicsComponentExtensions
{
	/// <summary>
	/// Returns an entity that the trigger collided with
	/// </summary>
	/// <param name="physicsComponent"></param>
	/// <returns></returns>
	public static async Task<Entity> GetCollidedEntity(this PhysicsComponent physicsComponent)
	{
		var firstCollision = await physicsComponent.NewCollision();

		var otherCollider = physicsComponent == firstCollision.ColliderA
			? firstCollision.ColliderB
			: firstCollision.ColliderA;

		return await Task.FromResult(otherCollider.Entity);
	}

	/// <summary>
	/// Returns True if the collider touches a specific Entity
	/// </summary>
	/// <param name="physicsComponent"></param>
	/// <param name="collidedCheck"></param>
	/// <returns></returns>
	public static async Task<bool> IsCollidingWithEntity(this PhysicsComponent physicsComponent, Entity collidedCheck)
	{
		var firstCollision = await physicsComponent.NewCollision();

		var otherCollider = physicsComponent == firstCollision.ColliderA
			? firstCollision.ColliderB
			: firstCollision.ColliderA;

		if(otherCollider.Entity == collidedCheck)
		{
			return await Task.FromResult(true);
		}

		await firstCollision.Ended();

		return await Task.FromResult(false);
	}

	/// <summary>
	/// Doesnt work as expected right now but its supposed to return true when it collides with a specified type
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="physicsComponent"></param>
	/// <returns></returns>
	public static async Task<bool> IsCollidingWithType<T>(this PhysicsComponent physicsComponent)where T: EntityComponent
	{
		var firstCollision = await physicsComponent.GetCollidedEntity();

		var result = firstCollision.GetComponent<T>();

		if (result != null)
		{
			if (result.Equals(typeof(T)))
			{
				return await Task.FromResult(true);
			}
		}
		return await Task.FromResult(false);
	}

}
