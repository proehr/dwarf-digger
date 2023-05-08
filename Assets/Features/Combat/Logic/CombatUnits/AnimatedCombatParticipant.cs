using System.Collections;
using System.Linq;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    public class AnimatedCombatParticipant : AbstractCombatParticipant
    {
        [SerializeField] protected internal Animator animator;
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
            StartCoroutine(StopUse());
        }

        protected virtual IEnumerator StopUse()
        {
            yield return new WaitForSeconds(tool.animationLength);
            isAttacking = false;
        }
    }
}