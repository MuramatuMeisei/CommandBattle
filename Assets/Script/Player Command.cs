using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand : MonoBehaviour
{
    private PlayerStatus playerStatus;

    //�U��
    [SerializeField] private int attackPower = 10;

    //�X�L��
    [SerializeField] private int skillSPCost = 10;
    [SerializeField] private float reflectChance = 0.8f;
    private int maxReflects = 3;
    private int currentReflects = 0;

    //�ǂ���
    [SerializeField] private int healItem = 20;
    [SerializeField] private int itemCount = 5;

    private void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    public void AttackCommand(Enemy target)
    {
        target.Damage(attackPower);
    }

    public void SkillCommand(Enemy target)
    {
        if (playerStatus.Skill(skillSPCost))
        {
            if(Random.value <= reflectChance)
            {
                currentReflects = maxReflects;
                Debug.Log("��𐬌�");
            }

            else
            {
                Debug.Log("������s");
            }
        }
    }

    public void ItemCommand()
    {
        if(itemCount > 0)
        {
            playerStatus.Heal(healItem);
            itemCount--;
            Debug.Log("�ǂ������g�p:HP��!!");
        }

        else
        {
            Debug.Log("�ǂ���������܂���");
        }
    }

    public void TakeEnemyDamage(int damage, Enemy enemy)
    {
        if(currentReflects > 0)
        {
            currentReflects--;
            enemy.Damage(damage);
            Debug.Log("�G�̍U���𔽎˂���");
        }

        else
        {
            playerStatus.Damage(damage);
            Debug.Log("�G����̃_���[�W");
        }
    }
}
