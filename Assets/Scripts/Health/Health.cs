using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    private void Awake()
    {
        //currentHealth = startingHealth;
        currentHealth = PlayerPrefs.GetFloat("_currentHealth");
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentHealth = startingHealth;
        }
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        AudioController.Ins.PlaySound(AudioController.Ins.loseSound);
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("isTakeHit");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("isDie");

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;

                GameGUIManager.Ins.ShowGameoverGui(true);
                GameGUIManager.Ins.ShowHomeGui(false);
            }
        }
        PlayerPrefs.SetFloat("_currentHealth", currentHealth);
        PlayerPrefs.Save();
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        PlayerPrefs.SetFloat("_currentHealth", currentHealth);
        PlayerPrefs.Save();
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);    
    }

}
