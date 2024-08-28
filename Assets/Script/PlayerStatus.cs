using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    //�v���C���[��HP
    public int maxHP = 100;
    public int currentHP;

    //�v���C���[��SP
    public int maxSP = 10;
    public int currentSP;

    //�A�C�e���̏�����
    public int itemCount = 5;

    //UI�e�L�X�g
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

    //�_���[�W
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP <= 0)
        {
            currentHP = 0;
            GameOver();
        }
    }

    //��
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

    //SP�̏���
    public bool UseSkill()
    {
        if(currentSP > 0)
        {
            currentSP--;
            return true;
        }

        return false;
    }

    //�X�VUI
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
