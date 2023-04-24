using MyBox;
using UnityEngine;

namespace Common.Logic.StateMachine
{
    [CreateAssetMenu(fileName = "CurrentState", menuName = "General_Logic/StateMachine/CurrentState", order = 0)]
    public class CurrentState_SO : ScriptableObject
    {
        [ReadOnly()] internal IState currentState;
    }
}