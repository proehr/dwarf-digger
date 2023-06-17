using System;
using System.Collections;
using Common.Logic.Variables;
using Features.PlayerControl.Logic;
using Features.StateSwitch.Logic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Combat.Logic.CombatUnits
{
    using System.Collections.Generic;
    using System.Linq;
    using Digging.Logic;

    [RequireComponent(typeof(PlayerInput))]
    public class PlayerCombatParticipant : MovingCombatParticipant
    {
        [SerializeField] private BoolVariable canMove;
        [SerializeField] private StateHandler stateHandler;
        [SerializeField] private List<DiggableObjectData> diggableObjectDatas;
        
        private Dictionary<string, DiggableObjectData> taggedDiggableObjectDatas = new();


        private GameState currentPlayerState;

        protected override void Awake() {
            base.Awake();
            taggedDiggableObjectDatas = diggableObjectDatas.ToDictionary(x => x.assignedTag,
                x => x);
        }

        private void Update()
        {
            if (currentAttackStats.AttackCooldown > 0)
            {
                currentAttackStats.AttackCooldown = Math.Max(currentAttackStats.AttackCooldown - Time.deltaTime, 0);
            }
        }

        protected internal override void ApplyMovementCooldown(float time)
        {
            currentMovementStats.MovementCooldown = Math.Max(currentMovementStats.MovementCooldown, time);
            if (currentMovementStats.MovementCooldown > 0)
            {
                canMove.SetFalse();
            }
        }

        protected override IEnumerator CheckForHit() {
            Debug.Log("Player Check for Hit entered");
            if (stateHandler.CurrentGameState == GameState.COMBAT) {
                Debug.Log("Player Check for Hit Combat entered");
                return base.CheckForHit();
            } else {
                Debug.Log("Player Check for Digging entered");
                return CheckForDiggingHit();
            }
        }
        
        
        private IEnumerator CheckForDiggingHit()
        {
            yield return new WaitForSeconds(tool.hitDetectionDelayInSeconds);
            if (Physics.Raycast(transform.position + Vector3.up * tool.hitHeight,
                    transform.TransformDirection(Vector3.forward), out var hit,
                    tool.maxHitDistance))
            {
                DiggableObjectData hitObjectData = taggedDiggableObjectDatas[hit.collider.tag];
                if (hitObjectData != null)
                {
                    Instantiate(hitObjectData.hitFx, hit.point, Quaternion.Inverse(transform.rotation));
                    StartCoroutine(DestroyBlockAfterTime(hit.collider.gameObject, hitObjectData.destructionTimeInSeconds));
                }
            }
        }
        
        protected virtual IEnumerator DestroyBlockAfterTime(GameObject colliderGameObject, float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(colliderGameObject);
        }

        public void StartAttack()
        {
            if (currentAttackStats.AttackCooldown <= 0)
            {
                Attack();
                // canMove.SetFalse();
            }
        }

        protected override IEnumerator StopUse()
        {
            yield return StartCoroutine(base.StopUse());
            canMove.SetTrue();
        }
        
#if UNITY_EDITOR
        protected void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position + Vector3.up * tool.hitHeight,
                transform.position + Vector3.up * tool.hitHeight + transform.forward * tool.maxHitDistance);
        }
#endif
    }
}
