using Stride.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doprez.Stride.StateMachines
{

    [ComponentCategory("FSM")]
    public class AsyncFiniteStateMachine : AsyncScript
	{
		/// <summary>
		/// All states that can be accessed by the FSM
		/// </summary>
		[DataMemberIgnore]
        public Dictionary<int, IAsyncState> States = new Dictionary<int, IAsyncState>();

        protected IAsyncState _currentState;

        public void Add(int id, IAsyncState state)
        {
            States.Add(id, state);
        }

		public override async Task Execute()
		{
            while (Game.IsRunning)
            {
                await _currentState.UpdateState();
            }
		}

		public IAsyncState GetActiveState()
        {
            return _currentState;
        }

        public IAsyncState GetState(int id)
		{
            return States[id];
		}

        public void SetCurrentState(IAsyncState state)
        {
            if (_currentState != null)
            {
                _currentState.ExitState();
            }

            _currentState = state;

            if (_currentState != null)
            {
                _currentState.EnterState();
            }
        }

        public void SetCurrentState(int stateIndex)
        {
            if (_currentState != null)
            {
                _currentState.ExitState();
            }

            _currentState = GetState(stateIndex);

            if (_currentState != null)
            {
                _currentState.EnterState();
            }
        }
	}
}
