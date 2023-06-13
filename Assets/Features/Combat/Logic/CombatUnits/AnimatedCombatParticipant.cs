using System.Collections;
using System.Linq;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    public class AnimatedCombatParticipant : AbstractCombatParticipant
    {
        [SerializeField] protected internal Animator animator;
        [SerializeField] protected internal Transform toolSlot;
        [SerializeField] protected internal CombatTool tool;

        protected override void Awake()
        {
            base.Awake();
            tool.user = this;
        }

        protected override void Attack()
        {
            base.Attack();
            UseTool();
        }

        protected virtual void UseTool()
        {
            PlayUsageAnimation();
        }

        protected virtual void PlayUsageAnimation()
        {
            tool.animationLength = animator.runtimeAnimatorController.animationClips
                .First(clip => clip.name == tool.animationName).length;
            animator.SetTrigger(tool.animationTriggerId);
            StartCoroutine(CheckForHit());
            StartCoroutine(StopUse());
        }

        private IEnumerator CheckForHit()
        {
            yield return new WaitForSeconds(tool.hitDetectionDelayInSeconds);
            if (Physics.Raycast(transform.position + Vector3.up * tool.hitHeight,
                    transform.forward,
                    out var hit,
                    tool.maxHitDistance
                ))
            {
                AbstractCombatParticipant hitCombatParticipant = hit.collider.GetComponent<AbstractCombatParticipant>();
                if (hitCombatParticipant != null)
                {
                    tool.ApplyAttackEffects(hitCombatParticipant);
                }
            }
        }

        protected virtual IEnumerator StopUse()
        {
            yield return new WaitForSeconds(tool.animationLength);
        }

        public void SetTool(CombatTool combatToolPrefab)
        {
            if (tool != null)
            {
                Destroy(tool.gameObject);
                tool = null;
            }

            if (combatToolPrefab != null)
            {
                tool = Instantiate(combatToolPrefab, toolSlot);
            }
        }
    }
}