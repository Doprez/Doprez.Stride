using Stride.Core;
using Stride.Engine;
using System.Collections.Generic;

namespace Doprez.Stride.StateMachines
{

    [ComponentCategory("FSM")]
    public class FiniteStateMachine : SyncScript
	{
		/// <summary>
		/// All states that can be accessed by the FSM
		/// </summary>
		[DataMemberIgnore]
        public Dictionary<int, IState> States = new Dictionary<int, IState>();

        protected IState _currentState;

        public FiniteStateMachine()
        {
        }

        public void Add(int id, IState state)
        {
            States.Add(id, state);
        }

        public IState GetActiveState()
        {
            return _currentState;
        }

        public IState GetState(int id)
		{
            return States[id];
		}

        public void SetCurrentState(IState state)
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

        public override void Update()
		{
            if (_currentState != null)
            {
                _currentState.UpdateState();
            }
        }
	}
}
