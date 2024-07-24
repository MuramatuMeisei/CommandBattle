using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //HP��SP
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int maxSP = 50;

    //���݂�HP��SP
    public int CurrentHP { get; private set; }
    public int CurrentSP { get; private set; }

    private void Start()
    {
        CurrentHP = maxHP;
        CurrentSP = maxSP;
    }

    //�_���[�W���󂯂���HP�����炷
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

    //�X�L�����g�p������SPCOST�����炷
    public bool Skill(int spCost)
    {
        if(CurrentSP >= spCost)
        {
            CurrentSP -= spCost;
            return true;
        }

        else
        {
            Debug.Log("SP������܂���");
            return false;
        }
    }

    //HP����
    public void Heal(int healAmount)
    {
        CurrentHP += healAmount;
        if(CurrentHP > maxHP)
        {
            CurrentHP = maxHP;
        }
    }
}
