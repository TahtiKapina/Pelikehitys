using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] protected string Name { get; set; }
    [field: SerializeField] protected float Health { get; set; }
    [field: SerializeField] protected float Damage { get; set; }


    public void takeDamage(int damageAmount)
    {
        Health -= damageAmount;
        Debug.Log($"{Name} sai {damageAmount} vahinkoa! HP: {Health}");

        if (Health <= 0)
        {
            Debug.Log($"{Name} hävisi taistelun!");
        }
    }

    public float GetHealth()
    {
        return Health;
    }

    public virtual void Attack()
    {
        Debug.Log($"{Name} hyökkää!");
    }

    public virtual void DealDamage(Character target)
    {
        Debug.Log($"{Name} aiheuttaa {Damage} vahinkoa kohteelle {target.Name}!");
        target.takeDamage((int)Damage);
    }
}
