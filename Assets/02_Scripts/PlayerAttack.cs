using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float curTime;
    [SerializeField ] float coolTime = 0.5f;

    private Animator anim;
    private PlayerMovement pm;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        Attack();
    }
    public void Attack()
    {
        

        if(curTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, z);
                anim.SetTrigger("PlayerAttack");
                curTime = coolTime;
                pm.isDash = true;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }
}
