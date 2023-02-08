using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doprez.Stride.StateMachines;
public interface IAsyncState
{

	public string Name { get; set; }
	public AsyncFiniteStateMachine FiniteStateMachine { get; set; }
	public bool IsDefaultState { get; set; }

	public Task EnterState();
	public Task ExitState();
	public Task UpdateState();

}
