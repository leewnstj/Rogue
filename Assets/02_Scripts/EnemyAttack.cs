using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float FollowDistance;
    [SerializeField] LayerMask layer;

    public void CheckPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (FollowDistance / 2), transform.position.y),
            Vector2.left, FollowDistance, layer);
        if (hit)
        {

        }
    }
}
