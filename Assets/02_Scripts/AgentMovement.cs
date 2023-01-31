using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Movement(Vector2 X)
    {
        rigid.velocity = new Vector2(X.x * MoveSpeed, rigid.velocity.y);
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
}
