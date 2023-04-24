using System;

namespace Common.Logic.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();

        bool HasNextState(IState nextState);
    }
}