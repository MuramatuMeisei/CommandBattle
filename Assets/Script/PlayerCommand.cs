using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCommand : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public EnemyStatus enemyStatus;

    public Button attackButton;
    public Button skillButton;
    public Button itemButton;

    public Text textHP;
    public Text textSP;

    private void Start()
    {
        attackButton.onClick.AddListener(OnAttackButtonClick);
        skillButton.onClick.AddListener(OnSkillButtonClick);
        itemButton.onClick.AddListener(OnItemButtonClick);

        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    void OnAttackButtonClick()
    {
        StartCoroutine(Attack());
    }

    void OnSkillButtonClick()
    {
        Skill();
    }

    void OnItemButtonClick()
    {
        Item();
    }

    IEnumerator Attack()
    {
        int damage = 10;
        enemyStatus.Damage(damage);

        yield return new WaitForSeconds(1f);

        int enemyDamage = 10;
        playerStatus.Damage(enemyDamage);
    }

    void Skill()
    {
        playerStatus.Skill();
    }

    void Item()
    {
        int healAmount = 10;
        playerStatus.Heal(healAmount);
    }

    void UpdateUI()
    {
        textHP.text = $"HP: {playerStatus.HP}";
        textSP.text = $"SP: {playerStatus.SP}";
    }
}
