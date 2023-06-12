using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.Logic.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Digging.Logic
{
    [RequireComponent(typeof(Animator))]
    public class Digger : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private BoolVariable isDigging;
        [SerializeField] private BoolVariable canMove;

        [SerializeField] private List<DiggableObjectData> diggableObjectDatas;
        [SerializeField] private float hitDetectionDelayInSeconds;
        [SerializeField] private float maxHitDistance;
        [SerializeField] private float hitHeight;

        private int animIdDig;
        private float digAnimationLength;

        private Dictionary<string, DiggableObjectData> taggedDiggableObjectDatas = new();

        private void Awake()
        {
            animIdDig = Animator.StringToHash("Attack");
            digAnimationLength = animator.runtimeAnimatorController.animationClips
                .First(clip => clip.name == "Attack (1)").length;
            taggedDiggableObjectDatas = diggableObjectDatas.ToDictionary(x => x.assignedTag,
                x => x);
        }

        private void OnAttack(InputValue value)
        {
            if (canMove.Get() && !isDigging.Get())
            {
                animator.SetTrigger(animIdDig);
                canMove.Set(false);
                StartCoroutine(CheckForHit());
                StartCoroutine(StopDig());
            }
        }

        private IEnumerator CheckForHit()
        {
            yield return new WaitForSeconds(hitDetectionDelayInSeconds);
            if (Physics.Raycast(transform.position + Vector3.up * hitHeight,
                    transform.TransformDirection(Vector3.forward), out var hit,
                    maxHitDistance))
            {
                DiggableObjectData hitObjectData = taggedDiggableObjectDatas[hit.collider.tag];
                if (hitObjectData != null)
                {
                    Instantiate(hitObjectData.hitFx, hit.point, Quaternion.Inverse(transform.rotation));
                    StartCoroutine(DestroyAfterTime(hit.collider.gameObject, hitObjectData.destructionTimeInSeconds));
                }
            }
        }

        protected virtual IEnumerator DestroyAfterTime(GameObject colliderGameObject, float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(colliderGameObject);
        }

        private IEnumerator StopDig()
        {
            yield return new WaitForSeconds(digAnimationLength);
            isDigging.Set(false);
            canMove.Set(true);
        }

#if UNITY_EDITOR
        protected void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position + Vector3.up * hitHeight,
                transform.position + Vector3.up * hitHeight + transform.forward * maxHitDistance);
        }
#endif
    }
}