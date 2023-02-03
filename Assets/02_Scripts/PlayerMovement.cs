using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    [SerializeField] Transform groundChkFront; 
    [SerializeField] Transform groundChkBack;

    [SerializeField] float PlayerSpeed;
    [SerializeField] float chkDistance;
    [SerializeField] float wallchkDistance;
    [SerializeField] float jumpPower;
    [SerializeField] float wallSlideSpeed;

    [SerializeField] LayerMask g_Layer;
    [SerializeField] LayerMask w_Layer;
    
    public bool isGround;
    public bool isWall;

    private float inputX;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMove();
        PlayerJump();
        ChkGround();
        ChkWall();
    }

    private void PlayerMove()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(inputX * PlayerSpeed, rigid.velocity.y);

        transform.localScale = inputX switch
        {
            1  => new Vector2(3.5f,3.5f),
            -1 => new Vector2(-3.5f,3.5f),
            _  => transform.localScale
        };

        anim.SetFloat("X", inputX);
    }

    private void PlayerJump()
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                rigid.gravityScale = 5f;
            }
        }
    }

    private void ChkGround()
    {
        bool ground_front = Physics2D.Raycast(groundChkFront.position, Vector2.down, chkDistance, g_Layer);
        bool ground_back = Physics2D.Raycast(groundChkBack.position, Vector2.down, chkDistance, g_Layer);

        if (!isGround && (ground_front || ground_back))
            rigid.velocity = new Vector2(rigid.velocity.x, 0);

        if (ground_front || ground_back)
            isGround = true;
        else
            isGround = false;
    }

    private void ChkWall()
    {
        isWall = Physics2D.Raycast(new Vector2(transform.position.x + (wallchkDistance / 2), transform.position.y)
            , Vector2.left, wallchkDistance, w_Layer);
        if (isWall && isGround == false)
        {
            rigid.gravityScale = wallSlideSpeed;
        }
        if (isWall == false)
        {
            rigid.gravityScale = 5;
        }
    }

    private void Dahs()
    {
    }
}
