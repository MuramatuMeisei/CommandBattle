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
        Debug.Log("�v���C���[�̃^�[��");
        // �v���C���[�̃^�[�����J�n�����Ƃ��ɕK�v�ȏ���
    }

    private void StartEnemyTurn()
    {
        playerTurn = false;
        Debug.Log("�G�̃^�[��");
        // �G���v���C���[�Ƀ_���[�W��^���鏈��
        enemyStatus.EnemyAttack(10);
        CheckGameOver();
        if (!IsGameOver())
        {
            StartPlayerTurn(); // �v���C���[�̃^�[���ɖ߂�
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
            Debug.Log("�Q�[���I�[�o�[�I�v���C���[�������܂���");
            // �Q�[���I�[�o�[����
        }
        else if (enemyStatus.HP <= 0)
        {
            Debug.Log("�Q�[���N���A�I�G���|����܂���");
            // �Q�[���N���A����
        }
    }

    private bool IsGameOver()
    {
        return playerStatus.HP <= 0 || enemyStatus.HP <= 0;
    }
}
