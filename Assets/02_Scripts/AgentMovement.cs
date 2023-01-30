using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] float PlayerSpeed;
    [SerializeField] float GroundHitDistance;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Movement(Vector2 X)
    {
        rigid.velocity = new Vector2(X.x * PlayerSpeed, rigid.velocity.y);
    }

    public void FlipMovement(Vector2 X)
    {
        transform.localScale = X.x switch
        {
            1 => new Vector2(1, 1),
            -1 => new Vector2(-1, 1),
            _ => transform.localScale
        };
    }

    public void Jump()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, GroundHitDistance)
    }
}
