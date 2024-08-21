using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public int HP { get; private set; } = 100;
    private bool isCleared = false;
    private PlayerStatus playerStatus;

    public Text hpText;      // �G��HP�\���pText
    public Text clearText;

    private void Start()
    {
        if (clearText != null)
        {
            clearText.enabled = false;
        }

        playerStatus = FindObjectOfType<PlayerStatus>();
        UpdateHPUI(); // ����HP�\�����X�V
    }

    public void EnemyAttack(int damage)
    {
        if (playerStatus != null)
        {
            playerStatus.TakeDamage(damage);
            Debug.Log($"�v���C���[��{damage}�̃_���[�W��^���܂���");
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        if (isCleared)
        {
            Debug.Log("�N���A");
            return;
        }

        HP -= damage;
        UpdateHPUI(); // HP���ύX���ꂽ���UI���X�V

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
        Debug.Log("�N���A");
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
            hpText.text = "�GHP: " + HP;
        }
    }
}
