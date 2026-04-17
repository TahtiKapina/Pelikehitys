using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

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

        Load();
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

        if (Keyboard.current.yKey.wasPressedThisFrame) 
        {
            Save();
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

    // Tallennetaan pelihahmon tilatiedot JSON tiedostoksi
    public void Save()
    {
        Debug.Log("Testi: JSON-tallenus käynnissä");

        // Luodaan playerData olio
        PlayerData playerData = new PlayerData(this);

        // Muodostetaan tilatiedosta JSON
        string json = JsonUtility.ToJson(playerData);

        // Tallenetaan JSON playerData.json nimiseen tiedostoon
        File.WriteAllText($"{Application.dataPath}/playerData.json", json);
    }

    public void Load()
    {
        Debug.Log("Testi: JSON-lataus käynissä");

        string json = File.ReadAllText($"{Application.dataPath}/playerData.json");

        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

        health.CurrentHealth = playerData.health;
    }
}

