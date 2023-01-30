using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputAgent : MonoBehaviour
{
    public UnityEvent<Vector2> PlayerMovement;
    public UnityEvent PlayerInput;

    private void Update()
    {
        PlayerMove();
        PlayerInputting();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        PlayerMovement?.Invoke(new Vector2(x, 0));
    }

    private void PlayerInputting()
    {
        PlayerInput.Invoke();
    }
}
