using System.Collections;
using System.Linq;
using Common.Logic.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Digging.Logic
{
    using System;
    using PlayerControl.Logic;

    public class Digger : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private BoolVariable isDigging;
        [SerializeField] private BoolVariable canMove;

        [SerializeField] private InputHandler handler;
        
        private int animIdDig;
        private float digAnimationLength;

        private void Awake()
        {
            animIdDig = Animator.StringToHash("Attack");
            digAnimationLength = animator.runtimeAnimatorController.animationClips
                .First(clip => clip.name == "Attack (1)").length;
        }

        private void StartDig()
        {
            Debug.Log("Digging Tool on Attack");
            if (canMove.Get() && !isDigging.Get())
            {
                Debug.Log("Digging Tool on Attack if");
                isDigging.SetTrue();
                animator.SetTrigger(animIdDig);
                canMove.SetFalse();
                StartCoroutine(StopDig());
            }
        }

        private IEnumerator StopDig()
        {
            Debug.Log("Stop Dig Pre Yield return");
            yield return new WaitForSeconds(digAnimationLength);
            Debug.Log("Stop Dig Post Yield return");
            isDigging.SetFalse();
            canMove.SetTrue();
        }

        public void OnEnable() {
            handler.onAttack += StartDig;
        }

        public void OnDisable() {
            isDigging.SetFalse();
            canMove.SetTrue();
            handler.onAttack -= StartDig;
        }
    }
}