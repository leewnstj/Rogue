using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    private Rigidbody2D rigid;
    private Animator anim;

    private float nowSizeX;
    private float nowSizeY;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nowSizeX = transform.localScale.x;
        nowSizeY = transform.localScale.y;
    }

    public void Movement(Vector2 X)
    {
        rigid.velocity = new Vector2(X.x * MoveSpeed, rigid.velocity.y);
        anim.SetFloat("X", X.x);
    }

    public void FlipMovement(Vector2 X)
    {
        transform.localScale = X.x switch
        {
            1 => new Vector2(nowSizeX, nowSizeY),
            -1 => new Vector2(-nowSizeX, nowSizeY),
            _ => transform.localScale
        };
    }
}
