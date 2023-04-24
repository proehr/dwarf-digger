using System;
using UnityEngine;

namespace Common.Logic.StateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        [SerializeField] internal CurrentState_SO currentStateSO;

        protected void InitializeStateMachine(IState initialState)
        {
            currentStateSO.currentState = initialState;
            currentStateSO.currentState.Enter();
        }

        protected void TransitionTo(IState targetState)
        {
            if (!currentStateSO.currentState.HasNextState(targetState))
                throw new InvalidOperationException("Invalid state transition: "
                                                    + currentStateSO.currentState.GetType().Name + " to "
                                                    + targetState.GetType().Name);

            currentStateSO.currentState.Exit();
            currentStateSO.currentState = targetState;
            currentStateSO.currentState.Enter();
        }
    }
}