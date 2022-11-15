using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* TASK: Comment on the code as we go through it
* Here we are doing Movement and Jumping
* Manipulate this script to add in a Jump function
* Extra Task: Add in Crouch or Sprint functions (or both)
*/

public class FPS_Movement : MonoBehaviour
{
    public CharacterController PlayerHeight;
    public CapsuleCollider playercol;
    public float normalHeight, crouchHeight;
    public Transform player;
    public Vector3 offset;
    public float dashmultiplier;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float walkSpeed; //handles decimal points/variable rate
    public float jumpHeight; //variable rate
    private float gravity = -9.81f; //constant rate of -10
    private CharacterController controller; //behaviour component controls characters
    private Vector3 velocity; //handles movement
    private Vector3 moveDirection; //movement


    void Start()
    {
        controller = GetComponent<CharacterController>(); //allows you to controll the character
    }
    
    void FixedUpdate()
    {
        Walking(); //best use for a walking code/smooth movement
    }  

    void Walking()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); //use only here
        float moveVertical = Input.GetAxisRaw("Vertical");   //use only here
        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward); //multiplying the movement vectors
        controller.Move(moveDirection * (Input.GetKey(KeyCode.LeftShift) ? walkSpeed * dashmultiplier : walkSpeed) * Time.deltaTime);  //allows you to move
        velocity.y += gravity * Time.deltaTime; //calculates smooth falling
        controller.Move(velocity * Time.deltaTime); //input of gravity to bring you down
    }
    void Update()
    {
        {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        }
        if (Input.GetKeyDown("space") && controller.isGrounded)
        {
            Debug.Log("space pressed");
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            PlayerHeight.height = crouchHeight;
            playercol.height = crouchHeight;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            PlayerHeight.height = normalHeight;
            playercol.height = normalHeight;
            player.position = player.position + offset;
        }
    }
   void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //allows you to jump
    }


}
