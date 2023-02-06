using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float AttackTime;
    [SerializeField] float coolTIme;
    private float curTime;

    private void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - attackPoint.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        attackPoint.rotation = Quaternion.Euler(0, 0, z);

        if(curTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("d");
            }
            curTime = AttackTime;
        }
        curTime -= Time.deltaTime;
    }
}
