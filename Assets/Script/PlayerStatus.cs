using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int HP { get; private set; } = 100;
    public int SP { get; private set; } = 50;

    private int skillCost = 10;

    public void Damage(int damage)
    {
        HP -= damage;
        if (HP < 0)
        {
            Debug.Log("HP:" + HP);
        }
    }

    public void Skill()
    {
        if(SP >= skillCost)
        {
            SP -= skillCost;
            Debug.Log("�X�L�����g�p");
        }

        else
        {
            Debug.Log("�X�L���g�p�s��");
        }
    }

    public void Heal(int amount)
    {
        HP += amount;
        Debug.Log("��");
    }
}
