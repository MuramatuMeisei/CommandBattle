using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    private PlayerStatus playerStatus;
    private EnemyStatus enemyStatus;
    private GameManager gameManager;

    public void Initialize(PlayerStatus playerStatus)
    {
        this.playerStatus = playerStatus;
        this.enemyStatus = FindObjectOfType<EnemyStatus>();
        this.gameManager = FindObjectOfType<GameManager>();
    }

    public void Attack()
    {
        Debug.Log("攻撃コマンド実行");
        PerformAction(10); // 攻撃で10のダメージを与える
    }

    public void Skill()
    {
        Debug.Log("スキルコマンド実行");

        if (playerStatus.SP > 0)
        {
            playerStatus.ChangeSP(-1); // スキルポイントを1減少
            bool isReflected = Random.value <= 0.8f; // 80%の確率で反射成功

            if (isReflected)
            {
                Debug.Log("スキル成功: 敵の攻撃を跳ね返しました");
                PerformAction(10); // 敵の攻撃を跳ね返して10のダメージを与える
            }
            else
            {
                Debug.Log("スキル失敗: もっと修行が必要です");
            }

            gameManager.EndPlayerTurn(); // プレイヤーのターン終了
        }
        else
        {
            Debug.Log("スキルポイントが不足しています");
        }
    }

    public void Item()
    {
        Debug.Log("アイテムコマンド実行");

        if (playerStatus.Item > 0)
        {
            playerStatus.ChangeItem(-1); // アイテムの数を1減少
            playerStatus.ChangeHP(10);   // HPを10回復
            Debug.Log("体力が10回復しました");
        }
        else
        {
            Debug.Log("アイテムが不足しています");
        }

        gameManager.EndPlayerTurn(); // プレイヤーのターン終了
    }

    private void PerformAction(int damage)
    {
        if (enemyStatus != null)
        {
            if (damage > 0)
            {
                enemyStatus.EnemyTakeDamage(damage); // 敵にダメージを与える
            }
            gameManager.EndPlayerTurn(); // プレイヤーのターン終了
        }
    }
}
