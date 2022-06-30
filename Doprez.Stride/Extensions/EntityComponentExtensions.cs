using Stride.Engine;
using System;
using System.Linq;

namespace Doprez.Stride.Extensions
{
	public static class EntityComponentExtensions
	{
        public static T GetComponent<T>(this Entity entity)
        {
            var result = entity.OfType<T>().FirstOrDefault();
            return result;
        }
    }
}
