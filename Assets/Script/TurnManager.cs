using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public PlayerStatus playerStatus;
    public EnemyStatus enemyStatus;
    public PlayerCommand playerCommand;

    private bool isPlayerTurn = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartPlayerTurn();
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    void StartPlayerTurn()
    {
        isPlayerTurn = true;
        EnablePlayerCommands(true);
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        EnablePlayerCommands(false);
        Invoke("StartEnemyTurn", 1f); // 敵のターンを少し遅れて開始する
    }

    void StartEnemyTurn()
    {
        if (enemyStatus.currentHP > 0 && playerStatus.currentHP > 0)
        {
            Debug.Log("敵からの攻撃:プレイヤーに10のダメージ");
            int damage = 10; // 敵の攻撃力
            playerStatus.TakeDamage(damage);

            // 敵のターン終了
            EndEnemyTurn();
        }
        else
        {
            EndEnemyTurn(); // ゲームオーバーまたはクリア状態で敵のターンを終了
        }
    }

    void EndEnemyTurn()
    {
        if (playerStatus.currentHP > 0 && enemyStatus.currentHP > 0)
        {
            StartPlayerTurn();
        }
        else if (playerStatus.currentHP <= 0)
        {
            Debug.Log("Game Over");
            // Game Over処理
        }
        else if (enemyStatus.currentHP <= 0)
        {
            Debug.Log("Clear");
            // ゲームクリア処理
        }
    }

    void EnablePlayerCommands(bool enable)
    {
        playerCommand.attackButton.interactable = enable;
        playerCommand.skillButton.interactable = enable;
        playerCommand.itemButton.interactable = enable;
    }
}
