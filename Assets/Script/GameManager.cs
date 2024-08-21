using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerStatus playerStatus;
    private EnemyStatus enemyStatus;
    private bool playerTurn = true;

    private void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        enemyStatus = FindObjectOfType<EnemyStatus>();
        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        playerTurn = true;
        Debug.Log("プレイヤーのターン");
        // プレイヤーのターンが開始したときに必要な処理
    }

    private void StartEnemyTurn()
    {
        playerTurn = false;
        Debug.Log("敵のターン");
        // 敵がプレイヤーにダメージを与える処理
        enemyStatus.EnemyAttack(10);
        CheckGameOver();
        if (!IsGameOver())
        {
            StartPlayerTurn(); // プレイヤーのターンに戻す
        }
    }

    public void EndPlayerTurn()
    {
        if (playerTurn)
        {
            StartEnemyTurn();
        }
    }

    private void CheckGameOver()
    {
        if (playerStatus.HP <= 0)
        {
            Debug.Log("ゲームオーバー！プレイヤーが負けました");
            // ゲームオーバー処理
        }
        else if (enemyStatus.HP <= 0)
        {
            Debug.Log("ゲームクリア！敵が倒されました");
            // ゲームクリア処理
        }
    }

    private bool IsGameOver()
    {
        return playerStatus.HP <= 0 || enemyStatus.HP <= 0;
    }
}
