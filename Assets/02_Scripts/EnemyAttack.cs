using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float FollowDistance;
    [SerializeField] float EnemySpeed;
    [SerializeField] LayerMask layer;

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
}
