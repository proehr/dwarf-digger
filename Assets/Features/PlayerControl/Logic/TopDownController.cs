using Common.Logic.Variables;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Features.PlayerControl.Logic
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    public class TopDownController : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;

        [SerializeField] private FloatVariable playerSpeed;
        [SerializeField] private bool isoCameraEnabled;

        [SerializeField] public float speedChangeRate = 10.0f;
        private Vector3 moveVector;

        private bool hasAnimator;
        private float animationBlend;

        private Animator animator;

        // animation IDs
        private int animIDSpeed;
        private int animIDGrounded;
        private int animIDFreeFall;
        private int animIDMotionSpeed;

        private float currentSpeed;
        // [SerializeField] private PlayerInput playerInput;

        // Start is called before the first frame update
        void Start()
        {
            hasAnimator = TryGetComponent(out animator);
            // Legacy stuff. We can remove this at some point
            animIDGrounded = Animator.StringToHash("Grounded");
            animIDFreeFall = Animator.StringToHash("FreeFall");
            animator.SetBool(animIDGrounded, true);
            animator.SetBool(animIDFreeFall, false);
            AssignAnimationIDs();
        }

        private void AssignAnimationIDs()
        {
            animIDSpeed = Animator.StringToHash("Speed");
            animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        }

        // Update is called once per frame
        void Update()
        {
            characterController.Move(moveVector * (Time.deltaTime * playerSpeed.Get()));
            if (!moveVector.Equals(Vector3.zero))
            {
                transform.forward = moveVector;
            }
        }

        private void OnFootstep(AnimationEvent animationEvent)
        {
        }

        private void OnMove(InputValue value)
        {
            Vector2 rawMoveVector = value.Get<Vector2>();
            currentSpeed = rawMoveVector == Vector2.zero ? 0.0f : playerSpeed.Get();
            
            // Different Movement if iso cam is enabled
            // HOTFIX
            if (isoCameraEnabled)
            {
                Vector3 skewedMoveVector = new Vector3(rawMoveVector[0], 0, rawMoveVector[1]);
                Matrix4x4 isoCorrectionMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
                moveVector = isoCorrectionMatrix.MultiplyPoint3x4(skewedMoveVector);
            }
            else
            {
                moveVector = new Vector3(rawMoveVector[0], 0, rawMoveVector[1]);
            }

            // animationBlend = Mathf.Lerp(animationBlend, currentSpeed, Time.deltaTime * speedChangeRate);
            animationBlend = currentSpeed;
            if (animationBlend < 0.01f) animationBlend = 0f;

            if (!hasAnimator) return;
            animator.SetFloat(animIDSpeed, animationBlend);
            // Input magnitude but i dont care for now
            animator.SetFloat(animIDMotionSpeed, 1f);
        }
    }
}