using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public int currentHP = 150;
    public int maxHP = 50;
    public Text enemyHpText;

    void Start()
    {
        // ‰ŠúHP‚ğİ’è
        currentHP = maxHP;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (enemyHpText != null)
        {
            enemyHpText.text = "Enemy HP: " + currentHP;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;
        UpdateUI();
    }
}
