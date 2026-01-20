using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input_Direct
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private float gravity = -9.81f;
        private float verticalVelocity;

        private CharacterController characterController;
        private Vector2 moveInput;

        [SerializeField] private InputActionReference moveAction;
        [SerializeField] private InputActionReference attackAction;
        [SerializeField] private InputActionReference jumpAction;

        private void Start()
        {
            // Hae CharacterController-komponentti
            characterController = GetComponent<CharacterController>();
        }
        private void OnEnable()
        {
            moveAction.action.Enable();
            attackAction.action.Enable();
            jumpAction.action.Enable();

            moveAction.action.performed += OnMovePerformed;
            moveAction.action.canceled += OnMovePerformed;
            attackAction.action.performed += OnAttackPerformed;
            jumpAction.action.performed += OnJumpPerformed;
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
            attackAction.action.Disable();
            jumpAction.action.Disable();

            moveAction.action.performed -= OnMovePerformed;

            moveAction.action.canceled -= OnMoveCanceled;

            attackAction.action.performed -= OnAttackPerformed;

            jumpAction.action.performed += OnJumpPerformed;
        }

        private void Update()
        {
            Move(moveInput);
        }
        void OnMovePerformed(InputAction.CallbackContext context)
        {
            moveInput = context.action.ReadValue<Vector2>();
        }

        void OnMoveCanceled(InputAction.CallbackContext context)
        {
            moveInput = Vector2.zero;
        }
        private void OnAttackPerformed(InputAction.CallbackContext context)
        {
            Debug.Log("Hyökkäys aktivoitu");
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            if (characterController.isGrounded)
            {
                verticalVelocity = 5f;
            }
        }

        private void Move(Vector2 moveInput)
        {
            if (characterController.isGrounded && verticalVelocity < 0f)
                verticalVelocity = -2f;
            verticalVelocity += gravity * Time.deltaTime;
            Vector3 direction = transform.right * moveInput.x +
            transform.forward * moveInput.y;
            Vector3 velocity = direction * moveSpeed + Vector3.up * verticalVelocity;

            characterController.Move(velocity * Time.deltaTime);

        }

    }
}