using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player has died!");
            //Destroy(this.gameObject);
            FindObjectOfType<GameOver>().EndGame();
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void addHealth()
    {
        if ((maxHealth - currentHealth) >= 20)
            currentHealth += 20;
        else
            currentHealth += (maxHealth - currentHealth);

        healthBar.SetHealth(currentHealth);
    }

    public void healthSkill()
    {
        currentHealth += 3;
        healthBar.SetHealth(currentHealth);
        
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }
}
