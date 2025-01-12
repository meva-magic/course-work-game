using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance
    {
        get{return _instance;}
    }

    private PlayerControlls playerControlls;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            _instance = this;
        }

        playerControlls = new PlayerControlls();
    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();   
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControlls.Player.Movement.ReadValue<Vector2>();
    }
}
