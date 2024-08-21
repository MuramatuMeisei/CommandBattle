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
        Debug.Log("�G��10�̃_���[�W");
    }

    public void Skill()
    {
        if(playerStatus.SP > 0)
        {
            playerStatus.ChangeSP(-1);

            bool isReflected = Random.value <= 0.8f;

            if (isReflected)
            {
                Debug.Log("�����@�G�̍U���𒵂˕Ԃ�");
            }

            else
            {
                Debug.Log("���s �����ƏC�s����!!");
            }
        }

        else
        {
            Debug.Log("�X�L���|�C���g������܂���");
        }
    }

    public void Item()
    {
        if(playerStatus.Item > 0)
        {
            playerStatus.ChangeItem(-1);

            playerStatus.ChangeHP(10);

            Debug.Log("�̗͂�10�񕜂���");
        }

        else
        {
            Debug.Log("�A�C�e�����s��");
        }
    }
}
