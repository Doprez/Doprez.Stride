﻿using Stride.Core.Mathematics;
using Stride.Engine;

namespace Stride.Physics;
public static  class SimulationExtensions
{
	/// <summary>
	/// A Raycast method based on the example in the fps demo
	/// <para>Make sure you are using the actual rotating Entity otherwise you will waste hours like I did debuging a non issue</para>
	/// </summary>
	public static HitResult RayCast(this Simulation simulation, Entity entityPosition, float length = 1, CollisionFilterGroupFlags collisionFlags = CollisionFilterGroupFlags.AllFilter)
	{
		var raycastStart = entityPosition.Transform.WorldMatrix.TranslationVector;
		var forward = entityPosition.Transform.WorldMatrix.Forward;
		var raycastEnd = raycastStart + forward * length;

		var result = simulation.Raycast(raycastStart, raycastEnd, filterFlags: collisionFlags);

		return result;
	}

	/// <summary>
	/// A Raycast method based on the example in the fps demo
	/// </summary>
	public static HitResult RayCast(this Simulation simulation, Entity entityPosition, Vector3 direction, float length = 1, CollisionFilterGroupFlags collisionFlags = CollisionFilterGroupFlags.AllFilter)
	{
		var raycastStart = entityPosition.Transform.WorldMatrix.TranslationVector;
		var raycastEnd = raycastStart + direction * length;

		var result = simulation.Raycast(raycastStart, raycastEnd, filterFlags: collisionFlags);

		return result;
	}
}
