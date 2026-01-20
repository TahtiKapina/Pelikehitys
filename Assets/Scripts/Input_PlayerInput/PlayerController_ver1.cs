using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_ver1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 5f;
    private float gravity = -9.81f;
    private float verticalVelocity;
    private CharacterController characterController;
    private Vector2 moveInput;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Move();
    }
    #region Send Message: Unity kutsuu On-alkuisia metodeja automaattisesti, kun syöte tapahtuu.
    // Liike

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        print(moveInput);
    }

    // Hyppy
    public void OnJump(InputValue value)
    {
        if (value.isPressed && characterController.isGrounded)
        {
            verticalVelocity = 5f;
        }
    }

    // Hyökkäys
    public void OnAttack(InputValue value)
    {
        Debug.Log("Hyökkäys aktioitu");
    }
    #endregion
    // --- LIIKKEEN LOGIIKKA ---
    private void Move()
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
