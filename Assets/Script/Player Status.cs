using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //HPとSP
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int maxSP = 50;

    //現在のHPとSP
    public int CurrentHP { get; private set; }
    public int CurrentSP { get; private set; }

    private void Start()
    {
        CurrentHP = maxHP;
        CurrentSP = maxSP;
    }

    //ダメージを受けたらHPを減らす
    public void Damage(int damage)
    {
        CurrentHP -= damage;
        if(CurrentHP < 0)
        {
            CurrentHP = 0;
        }

        if(CurrentHP == 0)
        {
            Debug.Log("GameOver");
        }
    }

    //スキルを使用したらSPCOSTを減らす
    public bool Skill(int spCost)
    {
        if(CurrentSP >= spCost)
        {
            CurrentSP -= spCost;
            return true;
        }

        else
        {
            Debug.Log("SPが足りません");
            return false;
        }
    }

    //HPを回復
    public void Heal(int healAmount)
    {
        CurrentHP += healAmount;
        if(CurrentHP > maxHP)
        {
            CurrentHP = maxHP;
        }
    }
}
