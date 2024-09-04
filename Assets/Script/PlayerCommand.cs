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

    public GameObject confirmationPanel;
    public Button doButton;
    public Button dontButton;

    private enum CommandType { None, Attack, Skill, Item }
    private CommandType selectedCommand = CommandType.None;

    void Start()
    {
        attackButton.onClick.AddListener(() => OnCommandButtonClicked(CommandType.Attack));
        skillButton.onClick.AddListener(() => OnCommandButtonClicked(CommandType.Skill));
        itemButton.onClick.AddListener(() => OnCommandButtonClicked(CommandType.Item));

        doButton.onClick.AddListener(OnDoButtonClicked);
        dontButton.onClick.AddListener(OnDontButtonClicked);

        confirmationPanel.SetActive(false);
    }

    void OnCommandButtonClicked(CommandType commandType)
    {
        if (playerStatus.IsTurn())
        {
            selectedCommand = commandType;
            confirmationPanel.SetActive(true);
            EnableCommandButtons(false);
        }
    }

    void OnDoButtonClicked()
    {
        switch (selectedCommand)
        {
            case CommandType.Attack:
                PerformAttack();
                break;
            case CommandType.Skill:
                PerformSkill();
                break;
            case CommandType.Item:
                UseItem();
                break;
        }
        EndPlayerTurn();
    }

    void OnDontButtonClicked()
    {
        selectedCommand = CommandType.None;
        confirmationPanel.SetActive(false);
        EnableCommandButtons(true);
    }

    void PerformAttack()
    {
        int damage = 10; // �U���̃_���[�W��
        enemyStatus.TakeDamage(damage);
        Debug.Log("�G��10�̃_���[�W");
    }

    void PerformSkill()
    {
        if (playerStatus.UseSkill())
        {
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
        }
        else
        {
            Debug.Log("SP������܂���");
        }
    }

    void UseItem()
    {
        if (playerStatus.itemCount > 0)
        {
            int healAmount = 20; // �񕜗�
            playerStatus.Heal(healAmount);
            playerStatus.itemCount--; // �A�C�e����1����
            Debug.Log("HP��20��");
            playerStatus.UpdateUI();

            if (playerStatus.itemCount <= 0)
            {
                itemButton.interactable = false;
            }
        }
        else
        {
            Debug.Log("�ǂ���������܂���");
        }
    }

    void EndPlayerTurn()
    {
        confirmationPanel.SetActive(false);
        TurnManager.Instance.EndPlayerTurn();
    }

    public void EnableCommandButtons(bool enable)
    {
        attackButton.interactable = enable;
        skillButton.interactable = enable;
        itemButton.interactable = enable;
    }
}
