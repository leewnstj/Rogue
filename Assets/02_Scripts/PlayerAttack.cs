using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float AttackTime;
    [SerializeField] float coolTIme;
    private float curTime;

    private void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        if(curTime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, attackPoint.position, transform.rotation);
            }
            curTime = AttackTime;
        }
        curTime -= Time.deltaTime;
    }
}
