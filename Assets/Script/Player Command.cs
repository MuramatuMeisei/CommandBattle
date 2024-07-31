using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand : MonoBehaviour
{
    private PlayerStatus playerStatus;

    //攻撃
    [SerializeField] private int attackPower = 10;

    //スキル
    [SerializeField] private int skillSPCost = 10;
    [SerializeField] private float reflectChance = 0.8f;
    private int maxReflects = 3;
    private int currentReflects = 0;

    //どうぐ
    [SerializeField] private int healItem = 20;
    [SerializeField] private int itemCount = 5;

    private void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    public void AttackCommand(Enemy target)
    {
        target.Damage(attackPower);
        Debug.Log("アタック");
        EndTurn();
    }

    public void SkillCommand(Enemy target)
    {
        if (playerStatus.Skill(skillSPCost))
        {
            if(Random.value <= reflectChance)
            {
                currentReflects = maxReflects;
                Debug.Log("回避成功");
            }

            else
            {
                Debug.Log("回避失敗");
            }

            EndTurn();
        }
    }

    public void ItemCommand()
    {
        if(itemCount > 0)
        {
            playerStatus.Heal(healItem);
            itemCount--;
            Debug.Log("どうぐを使用:HP回復!!");
        }

        else
        {
            Debug.Log("どうぐがありません");
        }

        EndTurn();
    }

    public void TakeEnemyDamage(int damage, Enemy enemy)
    {
        if(currentReflects > 0)
        {
            currentReflects--;
            enemy.Damage(damage);
            Debug.Log("敵の攻撃を反射した");
        }

        else
        {
            playerStatus.Damage(damage);
            Debug.Log("敵からのダメージ");
        }
    }

    void EndTurn()
    {
        FindObjectOfType<BattleManager>().EndEnemyTurn();
    }
}
