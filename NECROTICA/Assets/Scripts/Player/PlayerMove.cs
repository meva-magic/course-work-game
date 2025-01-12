using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 10f;
    [SerializeField] private float damping = 5f;

    private CharacterController controller;
    private Vector3 inputVector;
    private Vector3 movementVector;
    private bool isMoving;
    public bool isTalking;
    public static PlayerMove instance;

    [SerializeField] private Animator camAnim;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GetInput();
        MovePlayer();

        //camAnim.SetBool("isMoving", isMoving);
    }

    private void GetInput()
    {
        if(Input.GetKey(KeyCode.W) ||
           Input.GetKey(KeyCode.A) ||
           Input.GetKey(KeyCode.S) ||
           Input.GetKey(KeyCode.D))
        {
            isMoving = true;

            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);
        }

        else
        {
            isMoving = false;

            inputVector = Vector3.Lerp(inputVector, Vector3.zero, Time.deltaTime * damping);
        }

        movementVector = inputVector * playerSpeed;
    }

    private void MovePlayer()
    {
        controller.Move(movementVector * Time.deltaTime);
    }
}
