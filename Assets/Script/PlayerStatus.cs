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
            Debug.Log("スキルを使用");
        }

        else
        {
            Debug.Log("スキル使用不可");
        }
    }

    public void Heal(int amount)
    {
        HP += amount;
        Debug.Log("回復");
    }
}
