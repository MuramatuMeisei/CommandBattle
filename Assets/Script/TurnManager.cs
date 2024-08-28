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
        EnablePlayerCommands(true);
        skillSuccessful = false; // �v���C���[�̃^�[���J�n���ɃX�L�������t���O�����Z�b�g
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
            if (skillSuccessful) // �X�L�������������ꍇ
            {
                Debug.Log("�G��10�̃_���[�W");
                int damage = 10; // �X�L���������ɓG�ɗ^����_���[�W
                enemyStatus.TakeDamage(damage);
            }
            else // �X�L�������s�����ꍇ
            {
                Debug.Log("�G�̍U��");
                int damage = 10; // �G�̍U����
                playerStatus.TakeDamage(damage);
            }

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
