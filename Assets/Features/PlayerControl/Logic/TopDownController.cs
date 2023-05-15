using Common.Logic.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.PlayerControl.Logic
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    public class TopDownController : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;

        [SerializeField] private FloatVariable playerSpeed;

        private Vector3 moveVector;
        // [SerializeField] private PlayerInput playerInput;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            characterController.Move(moveVector * (Time.deltaTime * playerSpeed.Get()));
            transform.forward = moveVector;
        }

        private void OnMove(InputValue value)
        {
            Vector2 rawMoveVector = value.Get<Vector2>();
            moveVector = new Vector3(rawMoveVector[0], 0, rawMoveVector[1]);
        }
    }
}