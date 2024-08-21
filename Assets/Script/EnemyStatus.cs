using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public int HP { get; private set; } = 100;

    private bool isCread = false;

    public Text clearText;

    private void Start()
    {
        if(clearText != null)
        {
            clearText.enabled = false;
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        if (isCread)
        {
            Debug.Log("クリア");
            return;
        }

        HP -= damage;

        if(HP <= 0)
        {
            HP = 0;
            Clear();
        }
    }

    public void Clear()
    {
        if (isCread) return;

        isCread = true;
        Debug.Log("クリア");
        if(clearText != null)
        {
            clearText.enabled = true;
        }

        Destroy(gameObject);
    }
}
