using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player vastaa pelaajan toiminnasta (liikkuminen, hyökkäys).
/// </summary>
public class Player : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        // TODO: hae Health-komponentti
       health = GetComponent<Health>();
    }

    private void Start()
    {
        TakeDamage(1);
    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            TakeDamage(1);
        }

        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            TakeDamage(-1);
        }
    }

    public void TakeDamage(int amount)
    {        
        // TODO: vähennä elämää Healthin kautta
       health.Modify(-amount);
    }

    public void Heal(int amount)
    {
        health.Modify(amount);
    }
}

