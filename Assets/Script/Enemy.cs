using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    public int CurrentHP { get; private set; }

    private void Start()
    {
        CurrentHP = maxHP;
    }

    public void Damage(int damage)
    {
        CurrentHP -= damage;
        if(CurrentHP <= 0)
        {
            CurrentHP = 0;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("“G‚ð“|‚µ‚½");
    }
}
