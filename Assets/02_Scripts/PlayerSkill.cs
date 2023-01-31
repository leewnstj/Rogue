using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] float PlayerJumpPower;
    [SerializeField] float DashPower;

    [SerializeField] float DashCoolTime;
    [SerializeField] float GroundHitDistance;

    [SerializeField] LayerMask Ground;

    private bool isDash;
    private float CurrentDashTime;
    private float DashDirection;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, GroundHitDistance, Ground);
        if (Input.GetKeyDown(KeyCode.Space) && groundHit)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, PlayerJumpPower);
        }
    }

    public void Dash(Vector2 X)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDash = true;
            CurrentDashTime = DashCoolTime;
            rigid.velocity = Vector2.zero;
            DashDirection = (int)X.x;
        }
        if (isDash)
        {
            rigid.velocity = transform.right * DashPower * DashDirection;
            CurrentDashTime -= Time.deltaTime;
            if (CurrentDashTime <= 0)
            {
                isDash = false;
            }
        }
    }
}
