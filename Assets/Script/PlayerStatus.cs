using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int HP { get; private set; } = 100;
    public int SP { get; private set; } = 10;
    public int Item { get; private set; } = 5;

    private EnemyStatus enemyStatus;

    public Text gameOverText;
    public Text hpText;
    public Text spText;
    public Text itemText;

    public Button attackButton;
    public Button skillButton;
    public Button itemButton;

    private PlayerCommand playerCommands;

    private void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.enabled = false;
        }

        UpdateUI();

        playerCommands = GetComponent<PlayerCommand>();
        playerCommands.Initialize(this);

        attackButton.onClick.AddListener(playerCommands.Attack);
        skillButton.onClick.AddListener(playerCommands.Skill);
        itemButton.onClick.AddListener(playerCommands.Item);

        enemyStatus = FindObjectOfType<EnemyStatus>();
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        UpdateUI(); // HPが減少した後にUIを更新

        if (HP <= 0)
        {
            HP = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.enabled = true;
        }

        // ゲーム終了処理
        Debug.Log("Game Over!");
    }

    public void UseSkill()
    {
        if (SP > 0)
        {
            SP--;
            UpdateUI(); // SPを使用した後にUIを更新

            bool isReflected = UnityEngine.Random.Range(0f, 1f) <= 0.8f;

            if (isReflected)
            {
                Debug.Log("成功　敵の攻撃を跳ね返す");
                if (enemyStatus != null)
                {
                    enemyStatus.EnemyTakeDamage(10); // 敵にダメージを与える
                }
            }
            else
            {
                Debug.Log("失敗 もっと修行しろ!!");
            }
        }
        else
        {
            Debug.Log("スキルポイントが不足しています");
        }
    }

    public void UpdateUI()
    {
        if (spText != null)
        {
            spText.text = "SP: " + SP;
        }

        if (hpText != null)
        {
            hpText.text = "HP: " + HP;
        }

        if (itemText != null)
        {
            itemText.text = "Item: " + Item;
        }
    }

    public void ChangeHP(int amount)
    {
        HP = Mathf.Clamp(HP + amount, 0, 100);
        UpdateUI(); // HPが変更された後にUIを更新
    }

    public void ChangeSP(int amount)
    {
        SP = Mathf.Clamp(SP + amount, 0, 10);
        UpdateUI(); // SPが変更された後にUIを更新
    }

    public void ChangeItem(int amount)
    {
        Item = Mathf.Clamp(Item + amount, 0, 5);
        UpdateUI(); // アイテム数が変更された後にUIを更新
    }
}
