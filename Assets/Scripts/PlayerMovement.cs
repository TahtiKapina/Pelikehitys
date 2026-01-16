using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    void Update()
    {
        Vector2 moveInput = ReadMovementInput();

        HandleAttack();

        Move(moveInput);
    }

    private void Move(Vector2 moveInput)
    {
        // Laske pelaajan suunan
        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y;

        Vector3 velocity = direction * moveSpeed;



        characterController.Move(velocity * Time.deltaTime);
    }

    Vector2 ReadMovementInput()
    {
        // Alusta liikesyöte nollaksi
        Vector2 moveInput = Vector2.zero;

        // GAMEPAD: Tarkista onko peliohjain kytkettynä
        if (Gamepad.current != null)
        {
            moveInput = Gamepad.current.leftStick.ReadValue();
        }

        if (Keyboard.current != null)
        {
            float x = 0f;
            float y = 0f;


            if (Keyboard.current.aKey.isPressed) x -= 1f;
            if (Keyboard.current.dKey.isPressed) x += 1f;
            if (Keyboard.current.wKey.isPressed) y -= 1f;
            if (Keyboard.current.sKey.isPressed) y += 1f;

            moveInput = new Vector2(x, y).normalized;    
        }

        // Palauta liikesyöte kutsujalle
        return moveInput;
    }

    void HandleAttack()
    {
        if (Gamepad.current == null)
            return;

        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
        {
            Debug.Log("Hyökkäys aktivoitu");
        }
    }
}
