using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Text healthText;

    public int maxSkill = 10;
    public int currentSkill;
    public Text skillText;

    public Text textGameOver;

    private void Start()
    {
        currentHealth = maxHealth; //�Q�[���J�n���Ƀ��C�t��������
        currentSkill = maxSkill;
        UpdateUI(); //���C�tUI�̍X�V
        textGameOver.enabled = false;
    }

    public void Raduce(int raduce)
    {
        //���C�t�����炷
        currentHealth -= raduce;
        currentSkill -= raduce;
        UpdateUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //���C�tUI
    void UpdateUI()
    {
        healthText.text = "Health:" + currentHealth.ToString();
        skillText.text = "Skill:" + currentSkill.ToString();
    }

    void Die()
    {
        textGameOver.enabled = true;
    }
}
