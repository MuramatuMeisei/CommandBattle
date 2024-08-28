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
            // 敵にダメージを与える処理
            int damage = 10; // 攻撃のダメージ量
            enemyStatus.TakeDamage(damage);
            Debug.Log("敵に10のダメージ");
            EndPlayerTurn();
        }
    }

    void OnSkillButtonClicked()
    {
        if (playerStatus.IsTurn() && playerStatus.UseSkill())
        {
            // スキルを使用する処理
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

            EndPlayerTurn();
        }
        else
        {
            Debug.Log("SPがありません");
        }
    }

    void OnItemButtonClicked()
    {
        if (playerStatus.IsTurn() && playerStatus.itemCount > 0)
        {
            // HPを回復する処理
            int healAmount = 20; // 回復量
            playerStatus.Heal(healAmount);
            playerStatus.itemCount--; // アイテムを1つ消費
            Debug.Log("HPを20回復");
            playerStatus.UpdateUI(); // UIを更新

            if (playerStatus.itemCount <= 0)
            {
                itemButton.interactable = false; // アイテムがなくなったらボタンを無効にする
            }

            EndPlayerTurn();
        }
        else
        {
            Debug.Log("どうぐがありません");
        }
    }

    void EndPlayerTurn()
    {
        TurnManager.Instance.EndPlayerTurn();
    }
}
