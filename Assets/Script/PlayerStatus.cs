using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public int maxSkill = 3;
    private int currentSkill;

    private bool useSkill = true;

    private Text textGameOver;

    private void Start()
    {
        currentHealth = maxHealth;
        currentSkill = maxSkill;
        textGameOver.enabled = false;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void UseSkill()
    {
        if(useSkill && currentSkill > 0)
        {
            currentSkill--;
        }

        if(currentSkill == 0)
        {
            useSkill = false;
        }
    }

    void Die()
    {
        textGameOver.enabled = true;
    }
}
