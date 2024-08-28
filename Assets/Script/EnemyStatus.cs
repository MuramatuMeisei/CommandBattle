using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    //HP
    public int maxHP = 150;
    public int currentHP;

    //UIテキスト
    public Text hpText;
    public Text clearText;

    private void Start()
    {
        currentHP = maxHP;

        UpdateUI();

        clearText.gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP <= 0)
        {
            currentHP = 0;
            Clear();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        hpText.text = "Enemy HP: " + currentHP;
    }

    void Clear()
    {
        clearText.gameObject.SetActive(true);
        Debug.Log("Clear");
    }
}
