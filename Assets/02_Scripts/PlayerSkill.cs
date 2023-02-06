using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] float UltimateCoolTime;
    PlayerMovement pm;

    public bool isUltimate;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }
    public void SmokeSkill()
    {
        if (Input.GetMouseButtonDown(1))
        {

        }
    }

    public void UltimateSkill()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isUltimate = true;
        }
        if (isUltimate)
        {
            pm.isDash = true;
        }
    }
}
