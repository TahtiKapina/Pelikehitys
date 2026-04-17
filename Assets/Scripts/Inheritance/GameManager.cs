using UnityEngine;
using UnityEngine.InputSystem;

public class GameManagerTVS : MonoBehaviour
{
    public Character mage;
    public Character warrior;

    void Update()
    {
        while (mage.GetHealth() > 0 && warrior.GetHealth() > 0)
        {
            if (Keyboard.current.xKey.wasPressedThisFrame)
            {
                mage.Attack();
                warrior.takeDamage(15);
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                warrior.Attack();
                mage.takeDamage(20);
            }
        }
    }
}
