using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float FollowDistance;
    [SerializeField] float EnemySpeed;
    [SerializeField] float attackDis;
    [SerializeField] LayerMask layer;

    public bool canAttack = false;
    public bool stopAnim  = false;

    public void CheckPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (FollowDistance / 2), transform.position.y),
            Vector2.left, FollowDistance, layer);
        if (hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * EnemySpeed);
            if (hit.collider.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }

    public void Attack()
    {
        RaycastHit2D AttackHit = Physics2D.Raycast(new Vector2(transform.position.x + (attackDis / 2), transform.position.y),
            Vector2.left, attackDis, layer);
        if (AttackHit)
        {
            canAttack = true;
        }
        if (canAttack)
        {
            //attack anim start
        }
    }

    public void StopAttackAnim()
    {
        canAttack = false;
        stopAnim = true;
    }
}
