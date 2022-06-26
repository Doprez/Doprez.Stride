using Stride.Engine;
using System;
using System.Linq;

namespace Doprez.Stride.Extensions
{
	public static class EntityComponentExtensions
	{
		public static T GetComponent<T>(this Entity entity)
		{
			var type = typeof(T);

			var result = entity.GetAll<EntityComponent>().OfType<T>().FirstOrDefault();

			return result;
		}
	}
}
