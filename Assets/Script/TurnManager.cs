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
    private bool skillSuccessful = false;

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

    public void SetSkillSuccessful(bool successful)
    {
        skillSuccessful = successful;
    }

    void StartPlayerTurn()
    {
        isPlayerTurn = true;
        playerCommand.EnableCommandButtons(true);
        skillSuccessful = false;
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        playerCommand.EnableCommandButtons(false);
        Invoke("StartEnemyTurn", 1f);
    }

    void StartEnemyTurn()
    {
        if (enemyStatus.currentHP > 0 && playerStatus.currentHP > 0)
        {
            if (skillSuccessful)
            {
                Debug.Log("“G‚É10‚Ìƒ_ƒ[ƒW");
                int damage = 10;
                enemyStatus.TakeDamage(damage);
            }
            else
            {
                Debug.Log("“G‚ÌUŒ‚");
                int damage = 10;
                playerStatus.TakeDamage(damage);
            }

            EndEnemyTurn();
        }
        else
        {
            EndEnemyTurn();
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
        }
        else if (enemyStatus.currentHP <= 0)
        {
            Debug.Log("Clear");
        }
    }
}
