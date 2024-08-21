using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public int HP { get; private set; } = 100;
    private bool isCleared = false;
    private PlayerStatus playerStatus;

    public Text hpText;      // 敵のHP表示用Text
    public Text clearText;

    private void Start()
    {
        if (clearText != null)
        {
            clearText.enabled = false;
        }

        playerStatus = FindObjectOfType<PlayerStatus>();
        UpdateHPUI(); // 初期HP表示を更新
    }

    public void EnemyAttack(int damage)
    {
        if (playerStatus != null)
        {
            playerStatus.TakeDamage(damage);
            Debug.Log($"プレイヤーに{damage}のダメージを与えました");
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        if (isCleared)
        {
            Debug.Log("クリア");
            return;
        }

        HP -= damage;
        UpdateHPUI(); // HPが変更された後にUIを更新

        if (HP <= 0)
        {
            HP = 0;
            Clear();
        }
    }

    public void Clear()
    {
        if (isCleared) return;

        isCleared = true;
        Debug.Log("クリア");
        if (clearText != null)
        {
            clearText.enabled = true;
        }

        Destroy(gameObject);
    }

    private void UpdateHPUI()
    {
        if (hpText != null)
        {
            hpText.text = "敵HP: " + HP;
        }
    }
}
