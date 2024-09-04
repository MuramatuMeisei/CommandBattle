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
        int damage = 10; // 攻撃のダメージ量
        enemyStatus.TakeDamage(damage);
        Debug.Log("敵に10のダメージ");
    }

    void PerformSkill()
    {
        if (playerStatus.UseSkill())
        {
            bool skillSuccessful = Random.value < 0.8f; // 80%の確率でスキル成功
            TurnManager.Instance.SetSkillSuccessful(skillSuccessful);

            if (skillSuccessful)
            {
                Debug.Log("敵の攻撃を跳ね返す");
            }
            else
            {
                Debug.Log("失敗");
            }
        }
        else
        {
            Debug.Log("SPがありません");
        }
    }

    void UseItem()
    {
        if (playerStatus.itemCount > 0)
        {
            int healAmount = 20; // 回復量
            playerStatus.Heal(healAmount);
            playerStatus.itemCount--; // アイテムを1つ消費
            Debug.Log("HPを20回復");
            playerStatus.UpdateUI();

            if (playerStatus.itemCount <= 0)
            {
                itemButton.interactable = false;
            }
        }
        else
        {
            Debug.Log("どうぐがありません");
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
