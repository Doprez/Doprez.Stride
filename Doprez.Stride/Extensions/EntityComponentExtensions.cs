using Stride.Engine;
using Stride.Engine.Design;
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

	}
}
