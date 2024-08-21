using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCommand : MonoBehaviour
{
    private PlayerStatus playerStatus;

    public void Initialize(PlayerStatus playerStatus)
    {
        this.playerStatus = playerStatus;
    }

    public void Attack()
    {
        Debug.Log("敵に10のダメージ");
    }

    public void Skill()
    {
        if(playerStatus.SP > 0)
        {
            playerStatus.ChangeSP(-1);

            bool isReflected = Random.value <= 0.8f;

            if (isReflected)
            {
                Debug.Log("成功　敵の攻撃を跳ね返す");
            }

            else
            {
                Debug.Log("失敗 もっと修行しろ!!");
            }
        }

        else
        {
            Debug.Log("スキルポイントが足りません");
        }
    }

    public void Item()
    {
        if(playerStatus.Item > 0)
        {
            playerStatus.ChangeItem(-1);

            playerStatus.ChangeHP(10);

            Debug.Log("体力が10回復した");
        }

        else
        {
            Debug.Log("アイテムが不足");
        }
    }
}
