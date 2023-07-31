using UnityEngine;
using UnityEngine.AI;

namespace Features.EnemyMovement
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
    public class NavMeshAgentAnimator : MonoBehaviour 
    {

        private static readonly int ANIMATOR_PARAM_WALK_SPEED = 
            Animator.StringToHash("Speed");

        [SerializeField] private Animator animator;    
        [SerializeField] private NavMeshAgent agent;

        private void LateUpdate() 
        {
            animator.SetFloat(ANIMATOR_PARAM_WALK_SPEED, agent.velocity.magnitude);        
        }
    }
}