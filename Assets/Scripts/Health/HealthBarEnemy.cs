using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    public Slider slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    public void SetHealth(float curHealth, float maxHealth)
    {
        slider.gameObject.SetActive(curHealth < maxHealth);
        slider.value = curHealth;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
    }
    
}
