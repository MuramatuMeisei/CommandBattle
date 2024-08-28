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

    void Start()
    {
        attackButton.onClick.AddListener(OnAttackButtonClicked);
        skillButton.onClick.AddListener(OnSkillButtonClicked);
        itemButton.onClick.AddListener(OnItemButtonClicked);
    }

    void OnAttackButtonClicked()
    {
        if (playerStatus.IsTurn())
        {
            // �G�Ƀ_���[�W��^���鏈��
            int damage = 10; // �U���̃_���[�W��
            enemyStatus.TakeDamage(damage);
            Debug.Log("�G��10�̃_���[�W");
            EndPlayerTurn();
        }
    }

    void OnSkillButtonClicked()
    {
        if (playerStatus.IsTurn() && playerStatus.UseSkill())
        {
            // �X�L�����g�p���鏈��
            bool skillSuccessful = Random.value < 0.8f; // 80%�̊m���ŃX�L������

            TurnManager.Instance.SetSkillSuccessful(skillSuccessful);

            if (skillSuccessful)
            {
                Debug.Log("�G�̍U���𒵂˕Ԃ�");
            }
            else
            {
                Debug.Log("���s");
            }

            EndPlayerTurn();
        }
        else
        {
            Debug.Log("SP������܂���");
        }
    }

    void OnItemButtonClicked()
    {
        if (playerStatus.IsTurn() && playerStatus.itemCount > 0)
        {
            // HP���񕜂��鏈��
            int healAmount = 20; // �񕜗�
            playerStatus.Heal(healAmount);
            playerStatus.itemCount--; // �A�C�e����1����
            Debug.Log("HP��20��");
            playerStatus.UpdateUI(); // UI���X�V

            if (playerStatus.itemCount <= 0)
            {
                itemButton.interactable = false; // �A�C�e�����Ȃ��Ȃ�����{�^���𖳌��ɂ���
            }

            EndPlayerTurn();
        }
        else
        {
            Debug.Log("�ǂ���������܂���");
        }
    }

    void EndPlayerTurn()
    {
        TurnManager.Instance.EndPlayerTurn();
    }
}
