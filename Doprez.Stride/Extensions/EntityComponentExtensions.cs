using Stride.Core.Mathematics;
using System;
using System.Linq;

namespace Stride.Engine;

public static class EntityComponentExtensions
{

    /// <summary>
    /// Definitely not a rip off of Unity's GetComponent.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static T GetComponent<T>(this Entity entity)
    {
        var result = entity.OfType<T>().FirstOrDefault();
        return result;
    }

    /// <summary>
    /// Destroys the entity that calls this method.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static bool DestroyEntity(this Entity entity)
    {
        try
        {
            entity.Scene.Entities.Remove(entity);
            return true;
        }
        catch
        {
            return false;
        }
    }
	/// <summary>
	/// an easier way to get world position rather than Transform.WorldMatrix.TranslationVector
	/// </summary>
	/// <param name="entity"></param>
	/// <returns></returns>
	public static Vector3 WorldPosition(this Entity entity)
	{
		return entity.Transform.WorldMatrix.TranslationVector;
	}

	/// <summary>
	/// This is very inefficient but useful for quick testing to find a component in a scene
	/// <para>This method uses recursion if there are issues I may have done something silly here</para>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	public static T GetComponentInScene<T>(this Entity entity)
	{
        foreach(var entitiesInScene in entity.Scene.Entities)
        {
            var result = entitiesInScene.FindComponentInChildren<T>();

			if (result != null)
            {
                return result;
            }
        }

        return default;
	}


	/// <summary>
	/// This is very inefficient but useful for quick testing to find a component in a child Entity
	/// <para>This method uses recursion if there are issues I may have done something silly here</para>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	public static T FindComponentInChildren<T>(this Entity entity)
    {
        foreach(var currentEntity in entity.GetChildren())
        {
            var component = currentEntity.GetComponent<T>();
            var currentEntityChildren = currentEntity.GetChildren();

			if (component != null)
            {
                return component;
            }
            else if(currentEntityChildren.Count() > 0)
            {
                foreach(var childEntity in currentEntityChildren)
                {
                    var childComponent = childEntity.GetComponent<T>();

                    if(childComponent != null)
                    {
                        return childComponent;
                    }

                    childEntity.FindComponentInChildren<T>();
                }
            }
        }

        return default;
    }

	public static T FindComponentInScene<T>(this Entity entity)
	{
		foreach (var entitiesInScene in entity.Scene.Entities)
		{
			var result = entitiesInScene.FindComponentInChildren<T>();

			if (result != null)
			{
				return result;
			}
		}

		return default;
	}

	/// <summary>
	/// Vector3.Distance apparently already exists but I did the work for this soooooo...
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="pointA"></param>
	/// <param name="pointB"></param>
	/// <returns></returns>
	public static float GetDistanceBetweenVectors(this Entity entity, Vector3 pointA, Vector3 pointB)
	{
		var result = MathF.Sqrt
			(
				(pointB.X - pointA.X) * (pointB.X - pointA.X)
				+ (pointB.Y - pointA.Y) * (pointB.Y - pointA.Y)
				+ (pointB.Z - pointA.Z) * (pointB.Z - pointA.Z)
			);

		return result;
	}

	/// <summary>
	/// Vector3.Distance apparently already exists but I did the work for this soooooo...
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="pointB"></param>
	/// <returns></returns>
	public static float GetDistanceToVector3(this Entity entity, Vector3 pointB)
	{
        var pointA = entity.Transform.Position;
		var result = MathF.Sqrt
			(
				(pointB.X - pointA.X) * (pointB.X - pointA.X)
				+ (pointB.Y - pointA.Y) * (pointB.Y - pointA.Y)
				+ (pointB.Z - pointA.Z) * (pointB.Z - pointA.Z)
			);

		return result;
	}

	/// <summary>
	/// Returns the Y angle in radians between two Vector3's only using the X and Z values with fix for angle being 90 degrees off
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="targetPosition"></param>
	/// <returns></returns>
	public static float GetYAngleToTargetWithRightAngleFix(this Entity entity, Vector3 targetPosition)
	{
		var currentPosition = entity.Transform.WorldMatrix.TranslationVector;

		double angleInRadians = Math.Atan2(targetPosition.Z - currentPosition.Z, targetPosition.X - currentPosition.X);

		var angleinDegrees = MathUtil.RadiansToDegrees((float)angleInRadians) + 90;

		return MathUtil.DegreesToRadians(angleinDegrees);
	}

	/// <summary>
	/// Returns the Y angle in radians between two Vector3's only using the X and Z values
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="targetPosition"></param>
	/// <returns></returns>
	public static float GetYAngleToTarget(this Entity entity, Vector3 targetPosition)
	{
		var currentPosition = entity.Transform.WorldMatrix.TranslationVector;

		double angleInRadians = Math.Atan2(targetPosition.Z - currentPosition.Z, targetPosition.X - currentPosition.X);

		return (float)angleInRadians;
	}

}
