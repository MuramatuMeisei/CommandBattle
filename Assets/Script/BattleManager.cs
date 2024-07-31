using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public PlayerCommand playerCommand;
    public Enemy enemy;

    private enum Turn
    {
        Player,
        Enemy
    }

    private Turn currentTurn;

    private void Start()
    {
        currentTurn = Turn.Player;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        if(currentTurn == Turn.Player)
        {
            Debug.Log("Player Turn");
        }
    }

    void EnemyTurn()
    {
        if(currentTurn == Turn.Enemy)
        {
            Debug.Log("Enemy Turn");
            EnemyAction();
        }
    }

    void EnemyAction()
    {
        int damage = Random.Range(10, 0);
        playerCommand.TakeEnemyDamage(damage, enemy);

        EndEnemyTurn();
    }

    public void EndEnemyTurn()
    {
        if(currentTurn == Turn.Player)
        {
            currentTurn = Turn.Enemy;
            EnemyTurn();
        }

        else
        {
            currentTurn = Turn.Player;
            PlayerTurn();
        }
    }
}
