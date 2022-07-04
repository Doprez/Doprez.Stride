using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doprez.Stride.Interfaces
{
	public interface IInteractable
	{
		/// <summary>
		/// Interacts with the Entity
		/// </summary>
		public void Interact(Entity caller);
	}
}
