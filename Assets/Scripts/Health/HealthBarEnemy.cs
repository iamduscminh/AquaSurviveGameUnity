using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{

    [SerializeField] private Health enemyHealth;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        SetMaxHealth(enemyHealth.startingHealth);
    }
    private void Update()
    {
        SetHealth(enemyHealth.currentHealth);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
