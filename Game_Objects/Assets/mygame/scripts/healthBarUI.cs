using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;

    void Start()
    {
        if (slider == null)
            slider = GetComponent<Slider>();

        if (playerHealth != null)
        {
            slider.maxValue = playerHealth.maxHealth;
            slider.value = playerHealth.currentHealth;
        }
    }

    void Update()
    {
        if (playerHealth != null)
        {
            slider.value = playerHealth.currentHealth;
        }
    }
}