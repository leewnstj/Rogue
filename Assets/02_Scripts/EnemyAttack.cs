using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform attackPos;
    [SerializeField] Vector2 attackSize;

    private Animator anim;
    private Rigidbody2D rigid;

    private float curTime;
    public float coolTime = 0.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Attack();
    }
    private void Attack()
    {
        if (curTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D[] attackHit = Physics2D.OverlapBoxAll(attackPos.position, attackSize, 0);

                foreach (Collider2D collider in attackHit)
                {
                    Debug.Log(collider.tag);
                }

                anim.SetTrigger("PlayerAttack");
                curTime = coolTime;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(attackPos.position, attackSize);
    }
}
