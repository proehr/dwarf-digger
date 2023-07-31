using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    public class AnimatedCombatParticipant : AbstractCombatParticipant
    {
        [SerializeField] protected internal Animator animator;
        [SerializeField] protected internal Transform toolSlot;
        [SerializeField] protected internal CombatTool tool;
        [SerializeField] private float characterRadius;

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

        protected virtual IEnumerator CheckForHit()
        {
            yield return new WaitForSeconds(tool.hitDetectionDelayInSeconds);

            RaycastHit[] raycastHitsLeft = Physics.RaycastAll(
                transform.position + Vector3.left * characterRadius + Vector3.up * tool.hitHeight,
                transform.forward,
                tool.maxHitDistance
            );
            RaycastHit[] raycastHits = Physics.RaycastAll(
                transform.position + Vector3.up * tool.hitHeight,
                transform.forward,
                tool.maxHitDistance
            );
            RaycastHit[] raycastHitsRight = Physics.RaycastAll(
                transform.position + Vector3.right * characterRadius + Vector3.up * tool.hitHeight,
                transform.forward, tool.maxHitDistance);
            List<RaycastHit> hits = new();
            hits.AddRange(raycastHitsLeft);
            hits.AddRange(raycastHits);
            hits.AddRange(raycastHitsRight);

            foreach (RaycastHit hit in hits)
            {
                AbstractCombatParticipant hitCombatParticipant = hit.collider.GetComponent<AbstractCombatParticipant>();
                if (hitCombatParticipant != null)
                {
                    tool.ApplyAttackEffects(hitCombatParticipant);
                    break;
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
                tool.user = this;
            }
        }

#if UNITY_EDITOR
        protected void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position + Vector3.left * characterRadius + Vector3.up * tool.hitHeight,
                transform.position + Vector3.left * characterRadius + Vector3.up * tool.hitHeight +
                transform.forward * tool.maxHitDistance);
            Gizmos.DrawLine(transform.position + Vector3.up * tool.hitHeight,
                transform.position + Vector3.up * tool.hitHeight + transform.forward * tool.maxHitDistance);
            Gizmos.DrawLine(transform.position + Vector3.right * characterRadius + Vector3.up * tool.hitHeight,
                transform.position + Vector3.right * characterRadius + Vector3.up * tool.hitHeight +
                transform.forward * tool.maxHitDistance);
        }
#endif
    }
}