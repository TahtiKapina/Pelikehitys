using UnityEngine;
using UnityEngine.InputSystem;

public class Mage : Character
{
    void Start()
    {
        Damage = 15f;

        Debug.Log($"{Name} on valmis taisteluun! HP: {Health}");
    }
    void Update()
    {
        
    }

    public override void Attack()
    {
        Debug.Log($"{Name} heiitt‰‰ loitsun!");
    }
}
