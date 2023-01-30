using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [Header("플레이어 스탯")]
    [SerializeField] float PlayerSpeed;
    [SerializeField] float PlayerJumpPower;
    [SerializeField] float DashPower;

    [Header("세부 값")]
    [SerializeField] float DashCoolTime;
    [SerializeField] float GroundHitDistance;

    [Header("레이어")]
    [SerializeField] LayerMask Ground;

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
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, GroundHitDistance, Ground);
        if(Input.GetKeyDown(KeyCode.Space) && groundHit)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, PlayerJumpPower);
        }
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rigid.velocity = new Vector2(DashPower, 0);
        }
    }
}
