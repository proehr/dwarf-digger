using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    public class AggroPullHelper : MonoBehaviour
    {
        [SerializeField] protected internal AggroPullingParticipant pullingParticipant;

        private void OnCollisionEnter(Collision other)
        {
            AbstractCombatParticipant target = other.collider.GetComponent<AbstractCombatParticipant>();
            if (target && target.combatantGroup != pullingParticipant.combatantGroup && !pullingParticipant.targets.Contains(target))
            {
                NavMeshCombatParticipant navMeshCombatParticipant = target as NavMeshCombatParticipant;
                if (navMeshCombatParticipant && navMeshCombatParticipant.initialTarget == navMeshCombatParticipant.target)
                {
                    
                }
                pullingParticipant.targets.Add(target);
            }
        }
        
        private void OnCollisionExit(Collision other)
        {
            AbstractCombatParticipant target = other.collider.GetComponent<AbstractCombatParticipant>();
            if (target)
            {
                pullingParticipant.targets.Remove(target);
            }
        }

        public void AddTarget(AbstractCombatParticipant abstractCombatParticipant)
        {
            if (abstractCombatParticipant.combatantGroup != pullingParticipant.combatantGroup)
            {
                pullingParticipant.targets.Add(abstractCombatParticipant);
                abstractCombatParticipant.deathListeners += RemoveTarget;
                NavMeshCombatParticipant navMeshCombatParticipant = abstractCombatParticipant as NavMeshCombatParticipant;
                if (navMeshCombatParticipant && navMeshCombatParticipant.target == navMeshCombatParticipant.initialTarget)
                {
                    navMeshCombatParticipant.SetTarget(pullingParticipant);
                }
            }
        }

        private void RemoveTarget(AbstractCombatParticipant abstractCombatParticipant)
        {
            pullingParticipant.targets.Remove(abstractCombatParticipant);
        }
    }
}