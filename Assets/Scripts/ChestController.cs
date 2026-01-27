using UnityEngine;

/// <summary>
/// Avaa arkun
/// </summary>
public class ChestController : MonoBehaviour
{
    [SerializeField] private Animator chestAnimator;

    // TEHTÄVÄ:
    // 1. Tee julkinen metodi, jota toinen olio (esim. pelaaja, painike) voi kutsua
    
    public void OpenChest()
    {
        chestAnimator.SetTrigger("Open");
    }
}
