using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;
    public GameObject gameOverScreen;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver();
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        // Add any other game over logic here
    }
}