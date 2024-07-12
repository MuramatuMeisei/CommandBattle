using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int playerHP = 100;
    private int currentHP;
    public Text textHP;

    public int playerSP = 10;
    public int currentSP;
    public Text textSP;

    //���݂�HP��SP
    void Start()
    {
        currentHP = playerHP;
        currentSP = playerSP;
        StatusUI();
    }

    //�_���[�W���󂯂�
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }

        StatusUI();
    }

    //�X�L�����g�p
    public void UsesSkill(int spCost)
    {
        currentSP -= spCost;
        if (currentSP < 0)
        {
            currentSP = 0;
        }

        StatusUI();
    }

    public void HPheal(int healAmount)
    {
        currentHP += playerHP;
        if (currentHP > playerHP)
        {
            currentHP = playerHP;
        }

        StatusUI();
    }

    void StatusUI()
    {
        textHP.text = $"HP: {currentHP}/{playerHP}";
        textSP.text = $"SP: {currentSP}/{playerSP}";
    }
}
