using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doprez.Stride.StateMachines
{
	public interface IState
	{
		public FiniteStateMachine FiniteStateMachine { get; set; }

		public void EnterState();
		public void ExitState();
		public void UpdateState();
	}
}
