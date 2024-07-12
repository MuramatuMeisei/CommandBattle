using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    public PlayerStatus playerStatus;

    public Button attackButton;
    public Button skillButton;
    public Button toolButton;

    private bool skillActive = false;
    private int reflectCount = 0;
    private int items = 5;

    private bool hasPerformedAction = false;

    private void Start()
    {
        attackButton.onClick.AddListener(Attack);
        skillButton.onClick.AddListener(Skill);
        toolButton.onClick.AddListener(Tool);
    }

    void Attack()
    {
        if (!hasPerformedAction)
        {
            Debug.Log("攻撃");
            hasPerformedAction = true;
            EndTurn();
        }
    }

    //スキル使用
    void Skill()
    {
        if(!skillActive && playerStatus.currentSP >= 1)
        {
            playerStatus.UsesSkill(1);
            if(Random.value < 0.8f)
            {
                skillActive = true;
                reflectCount = 3;
                Debug.Log("スキル使用成功");
            }

            else
            {
                Debug.Log("スキル使用失敗");
            }

            hasPerformedAction = true;
            EndTurn();
        }
    }

    void Tool()
    {
        if(!hasPerformedAction && items > 0)
        {
            playerStatus.HPheal(20);
            items--;
            Debug.Log("HP回復");
            hasPerformedAction = true;
            EndTurn();
        }

        else if(!hasPerformedAction)
        {
            Debug.Log("HP回復できません");
            hasPerformedAction = true;
            EndTurn();
        }
    }

    void EndTurn()
    {

    }

    public void ReceiveAttack(int damage)
    {
        if(skillActive && reflectCount > 0)
        {
            reflectCount--;
            if(reflectCount == 0)
            {
                skillActive = false;
            }

            else
            {
                playerStatus.TakeDamage(damage);
            }
        }
    }
}
