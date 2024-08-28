using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int currentHP = 100;
    public int maxHP = 100;
    public int currentSP = 10;
    public int maxSP = 10;
    public Text hpText;
    public Text spText;
    public Text itemCountText;
    public int itemCount = 5;

    void Start()
    {
        currentHP = maxHP;
        currentSP = maxSP;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;
        UpdateUI();
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;
        UpdateUI();
    }

    public bool UseSkill()
    {
        if (currentSP > 0)
        {
            currentSP--;
            UpdateUI();
            return true;
        }
        return false;
    }

    public void UpdateUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHP;
        }
        if (spText != null)
        {
            spText.text = "SP: " + currentSP;
        }
        if (itemCountText != null)
        {
            itemCountText.text = "Items: " + itemCount;
        }
    }

    public bool IsTurn()
    {
        return TurnManager.Instance.IsPlayerTurn();
    }
}
