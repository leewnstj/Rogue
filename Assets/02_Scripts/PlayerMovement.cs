using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    [SerializeField] Transform groundChkFront; 
    [SerializeField] Transform groundChkBack;

    [SerializeField] float PlayerSpeed;
    [SerializeField] float chkDistance;
    [SerializeField] float wallchkDistance;
    [SerializeField] float jumpPower;
    [SerializeField] float wallSlideSpeed;
    [Header("Dash")]
    [SerializeField] float DashCoolTime;
    [SerializeField] float DashPower;

    [SerializeField] LayerMask g_Layer;
    [SerializeField] LayerMask w_Layer;
    
    public bool isGround;
    public bool isWall;
    public bool isDash;
    public bool isSlideWall;
    public bool isDown;

    public float inputX;
    private float currentDashTime;
    private float dashDis;


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
        Dash();
    }

    private void PlayerMove()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(inputX * PlayerSpeed, rigid.velocity.y);

        transform.rotation = inputX switch
        {
            1  => Quaternion.Euler(0,0,0),
            -1 => Quaternion.Euler(0,180,0),
            _  => transform.rotation
        };

        anim.SetFloat("X", inputX);
    }

    private void PlayerJump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        }
        if (rigid.velocity.y < 0 && isSlideWall == false)
        {
            anim.SetTrigger("PlayerDown");
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
        if (isWall)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, wallSlideSpeed);
        }
        if(isWall && isGround == false)
        {
            isSlideWall = true;
        }
        else
        {
            isSlideWall = false;
        }
        anim.SetBool("SlideWall", isSlideWall);
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDash = true;
            currentDashTime = DashCoolTime;
            rigid.velocity = Vector2.zero;
            rigid.gravityScale = 0;
            dashDis = (int)inputX;
        }
        if (isDash)
        {
            rigid.velocity = transform.right * dashDis * DashPower;
            currentDashTime -= Time.deltaTime;
            if(currentDashTime <= 0)
            {
                isDash = false;
                rigid.gravityScale = 5;
            }

            if (isGround)
            {
                anim.SetBool("PlayerGroundDash", isDash);
            }
            else
            {
                anim.SetBool("PlayerDash", isDash);
            }
        }
    }
}
