using Stride.Engine;
using System;
using System.Linq;

namespace Doprez.Stride.Extensions
{
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
    }
}
