using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public EnemyStatus enemyStatus;

    public Button attackButton;
    public Button skillButton;
    public Button itemButton;

    private void Start()
    {
        attackButton.onClick.AddListener(OnAttack);
        skillButton.onClick.AddListener(OnSkill);
        itemButton.onClick.AddListener(OnItem);
    }

    //攻撃コマンド
    void OnAttack()
    {
        int damage = 10;
        enemyStatus.TakeDamage(damage);
    }

    //スキルコマンド
    void OnSkill()
    {
        if (playerStatus.UseSkill())
        {
            float reflectChance = 0.8f;

            if(Random.value < reflectChance)
            {
                int damage = 10;
                enemyStatus.TakeDamage(damage);
            }

            else
            {
                playerStatus.TakeDamage(10);
            }
        }
    }

    void OnItem()
    {
        int healAmount = 10;
        playerStatus.Heal(healAmount);
    }
}
