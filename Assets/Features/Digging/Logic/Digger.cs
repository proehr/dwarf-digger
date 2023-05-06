using System.Collections;
using System.Linq;
using Common.Logic.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Digging.Logic
{
    public class Digger : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private BoolVariable isDigging;
        [SerializeField] private BoolVariable canMove;

        private int animIdDig;
        private float digAnimationLength;

        private void Awake()
        {
            animIdDig = Animator.StringToHash("Dig");
            digAnimationLength = animator.runtimeAnimatorController.animationClips
                .First(clip => clip.name == "Attack (1)").length;
        }

        private void OnDig(InputValue value)
        {
            if (canMove.Get() && !isDigging.Get())
            {
                isDigging.Set(value.isPressed);
                animator.SetTrigger(animIdDig);
                canMove.Set(false);
                StartCoroutine(StopDig());
            }
        }

        private IEnumerator StopDig()
        {
            yield return new WaitForSeconds(digAnimationLength);
            isDigging.Set(false);
            canMove.Set(true);
        }
    }
}