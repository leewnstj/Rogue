using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float curTime;
    [SerializeField ] float coolTime = 0.5f;

    private Animator anim;
    private PlayerMovement pm;
    private SpriteRenderer sr;
    private Rigidbody2D rigid;
    float dd;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();

        dd = transform.rotation.z;
    }
    private void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if (curTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, z);

                rigid.AddForce(new Vector3(len.x, len.y)* 10 ,ForceMode2D.Impulse);


                anim.SetTrigger("PlayerAttack");
                curTime = coolTime;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }
}
