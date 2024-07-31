using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int HP { get; private set; } = 100;


    public void Damage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
        Debug.Log("‚­‚ç‚Á‚½");
    }
}
