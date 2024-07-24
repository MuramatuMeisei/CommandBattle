using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //HPÇ∆SP
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int maxSP = 50;

    //åªç›ÇÃHPÇ∆SP
    public int CurrentHP { get; private set; }
    public int CurrentSP { get; private set; }

    private void Start()
    {
        CurrentHP = maxHP;
        CurrentSP = maxSP;
    }

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

    public bool Skill(int spCost)
    {
        if(CurrentSP >= spCost)
        {
            CurrentSP -= spCost;
            return true;
        }

        else
        {
            Debug.Log("SPÇ™ë´ÇËÇ‹ÇπÇÒ");
            return false;
        }
    }
}
