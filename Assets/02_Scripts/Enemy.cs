using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent EnemyAttack;

    private void Update()
    {
        EnemyAttacking();
    }

    private void EnemyAttacking()
    {
        EnemyAttack.Invoke();
    }
}
