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
        Invoke("StartEnemyTurn", 1f); // �G�̃^�[���������x��ĊJ�n����
    }

    void StartEnemyTurn()
    {
        if (enemyStatus.currentHP > 0 && playerStatus.currentHP > 0)
        {
            Debug.Log("�G����̍U��:�v���C���[��10�̃_���[�W");
            int damage = 10; // �G�̍U����
            playerStatus.TakeDamage(damage);

            // �G�̃^�[���I��
            EndEnemyTurn();
        }
        else
        {
            EndEnemyTurn(); // �Q�[���I�[�o�[�܂��̓N���A��ԂœG�̃^�[�����I��
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
            // Game Over����
        }
        else if (enemyStatus.currentHP <= 0)
        {
            Debug.Log("Clear");
            // �Q�[���N���A����
        }
    }

    void EnablePlayerCommands(bool enable)
    {
        playerCommand.attackButton.interactable = enable;
        playerCommand.skillButton.interactable = enable;
        playerCommand.itemButton.interactable = enable;
    }
}
