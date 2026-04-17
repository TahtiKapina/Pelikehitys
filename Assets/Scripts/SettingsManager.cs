using UnityEngine; 
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    // Referenssi TMP_Dropdown-komponenttiin hyppyn‰pp‰imen valitsemiseksi
    [SerializeField] TMP_Dropdown jumpKeyInput;

    // Referenssi Slider-komponenttiin ‰‰nenvoimakkuuden s‰‰t‰miseksi
    [SerializeField] Slider volumeSlider;

    [SerializeField] Slider sensitivitySlider;

    [SerializeField] TMP_Dropdown graphicsInput;

    private void Start()
    {
        // Lataa hyppyn‰pp‰imen asetus PlayerPrefseist‰.
        // Oletusarvo on 0, jos asetusta ei ole tallennettu
        jumpKeyInput.value = PlayerPrefs.GetInt("JumpKey", 0);

        // Lataa ‰‰nenvoimakkuuden asetus PlayerPrefseist‰.
        // Oletusarvo on 0.5f, jos asetusta ei ole tallennettu
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
    }

    public void SaveSettings()
    {
        // Tallentaa hyppyn‰pp‰imen asetuksen PlayerPrefsiin
        PlayerPrefs.SetInt("JumpKey", jumpKeyInput.value);

        // Tallentaa ‰‰nenvoimakkuuden asetuksen PlayerPrefsiin
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);

        PlayerPrefs.SetInt("Graphics", graphicsInput.value);

        
        PlayerPrefs.Save();
    }

    public void ResetSettings()
    {
        PlayerPrefs.DeleteAll();

        jumpKeyInput.value = 0;
        volumeSlider.value = 0.5f;
        graphicsInput.value = 0;
        sensitivitySlider.value = 0.5f;
    }
}