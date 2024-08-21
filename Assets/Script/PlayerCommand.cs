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
        Debug.Log("�U���R�}���h���s");
        PerformAction(10); // �U����10�̃_���[�W��^����
    }

    public void Skill()
    {
        Debug.Log("�X�L���R�}���h���s");

        if (playerStatus.SP > 0)
        {
            playerStatus.ChangeSP(-1); // �X�L���|�C���g��1����
            bool isReflected = Random.value <= 0.8f; // 80%�̊m���Ŕ��ː���

            if (isReflected)
            {
                Debug.Log("�X�L������: �G�̍U���𒵂˕Ԃ��܂���");
                PerformAction(10); // �G�̍U���𒵂˕Ԃ���10�̃_���[�W��^����
            }
            else
            {
                Debug.Log("�X�L�����s: �����ƏC�s���K�v�ł�");
            }

            gameManager.EndPlayerTurn(); // �v���C���[�̃^�[���I��
        }
        else
        {
            Debug.Log("�X�L���|�C���g���s�����Ă��܂�");
        }
    }

    public void Item()
    {
        Debug.Log("�A�C�e���R�}���h���s");

        if (playerStatus.Item > 0)
        {
            playerStatus.ChangeItem(-1); // �A�C�e���̐���1����
            playerStatus.ChangeHP(10);   // HP��10��
            Debug.Log("�̗͂�10�񕜂��܂���");
        }
        else
        {
            Debug.Log("�A�C�e�����s�����Ă��܂�");
        }

        gameManager.EndPlayerTurn(); // �v���C���[�̃^�[���I��
    }

    private void PerformAction(int damage)
    {
        if (enemyStatus != null)
        {
            if (damage > 0)
            {
                enemyStatus.EnemyTakeDamage(damage); // �G�Ƀ_���[�W��^����
            }
            gameManager.EndPlayerTurn(); // �v���C���[�̃^�[���I��
        }
    }
}
