using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    //プレイヤーのHP
    public int maxHP = 100;
    public int currentHP;

    //プレイヤーのSP
    public int maxSP = 10;
    public int currentSP;

    //アイテムの所持数
    public int itemCount = 5;

    //UIテキスト
    public Text hpText;
    public Text spText;
    public Text itemText;
    public Text gameOverText;

    private void Start()
    {
        currentHP = maxHP;
        currentSP = maxSP;

        UpdateUI();

        gameOverText.gameObject.SetActive(false);
    }

    //ダメージ
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP <= 0)
        {
            currentHP = 0;
            GameOver();
        }
    }

    //回復
    public void Heal(int amount)
    {
        if(itemCount > 0)
        {
            currentHP += amount;

            if(currentHP > maxSP)
            {
                currentHP = maxHP;
            }

            itemCount--;
        }
    }

    //SPの消費
    public bool UseSkill()
    {
        if(currentSP > 0)
        {
            currentSP--;
            return true;
        }

        return false;
    }

    //更新UI
    void UpdateUI()
    {
        hpText.text = "HP: " + currentHP;
        spText.text = "SP: " + currentSP;
        itemText.text = "Item " + itemCount;
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        Debug.Log("GameOver");
    }
}
