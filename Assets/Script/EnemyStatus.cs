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
        // 初期HPを設定
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
