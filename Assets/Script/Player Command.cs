using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand : MonoBehaviour
{
    private PlayerStatus playerStatus;

    //UŒ‚
    [SerializeField] private int attackPower = 10;

    //ƒXƒLƒ‹
    [SerializeField] private int skillSPCost = 10;
    [SerializeField] private float reflectChance = 0.8f;
    private int maxReflects = 3;
    private int currentReflects = 0;

    //‚Ç‚¤‚®
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
                Debug.Log("‰ñ”ğ¬Œ÷");
            }

            else
            {
                Debug.Log("‰ñ”ğ¸”s");
            }
        }
    }

    public void ItemCommand()
    {
        if(itemCount > 0)
        {
            playerStatus.Heal(healItem);
            itemCount--;
            Debug.Log("‚Ç‚¤‚®‚ğg—p:HP‰ñ•œ!!");
        }

        else
        {
            Debug.Log("‚Ç‚¤‚®‚ª‚ ‚è‚Ü‚¹‚ñ");
        }
    }

    public void TakeEnemyDamage(int damage, Enemy enemy)
    {
        if(currentReflects > 0)
        {
            currentReflects--;
            enemy.Damage(damage);
            Debug.Log("“G‚ÌUŒ‚‚ğ”½Ë‚µ‚½");
        }

        else
        {
            playerStatus.Damage(damage);
            Debug.Log("“G‚©‚ç‚Ìƒ_ƒ[ƒW");
        }
    }
}
