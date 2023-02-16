using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float attackTime;
    public float curenTime;

    private PlayerMovement pm;
    private Animator anim;

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
   

        if(curenTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.rotation = Quaternion.Euler(0, 0, z);
                if(z >= 90 && z <= -90)
                {
                    transform.rotation = Quaternion.Euler(0, 180 ,0);
                }
                anim.SetTrigger("PlayerAttack");
                curenTime = attackTime;
            }
        }
        else
        {
            curenTime -= Time.deltaTime;
        }
    }

    public void StopAnim()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
