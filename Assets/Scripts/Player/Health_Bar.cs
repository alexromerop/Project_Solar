using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
public Text healthText;
    public Image healthBar, ringHealthBar;

    public ThirdPersonMovement personaje;
    public Image[] healthPoints;

    float health, maxHealth = 100;
    float lerpSpeed;

    private void Start()
    {
        if(personaje)
        personaje.vida = maxHealth;
    }

    private void Update()
    {
        if(personaje)
        if(personaje.vida >= 100f){
            if(healthBar)
            healthBar.enabled = false;
            
        }
        else{
            if (healthBar)
                healthBar.enabled=true;
        }
        if (healthText && personaje)
        {
            healthText.text = "Health: " + personaje.vida + "%";
            if (personaje.vida > maxHealth) personaje.vida = maxHealth;

            lerpSpeed = 3f * Time.deltaTime;

            HealthBarFiller();
            ColorChanger();
        }
        
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (personaje.vida / maxHealth), lerpSpeed);
        ringHealthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (personaje.vida / maxHealth), lerpSpeed);

        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayHealthPoint(personaje.vida, i);
        }
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.cyan, (personaje.vida / maxHealth));
        healthBar.color = healthColor;
        ringHealthBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    public void Damage(float damagePoints)
    {
        if (personaje.vida > 0)
            personaje.vida -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (personaje.vida < maxHealth)
            personaje.vida += healingPoints;
    }
}
