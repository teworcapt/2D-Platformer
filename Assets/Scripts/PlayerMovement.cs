using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Speed (Speed Navigation Ingame)
    public float moveSpeed;

    //RigidBody (Physics)
    public Rigidbody2D rigidBody;

    // Where Player moves
    private Vector2 movementInput;

    // Access Animator to play animations
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //gets component/information on the player and stores it on the variables
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if W is pressed 
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("BackwardAnimation");
        }

        //if W is released
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("BackwardAnimationPause");
        }
        //if A is pressed 
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("LeftAnimation");
        }

        //if A is released
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTrigger("LeftAnimationPause");
        }

        //if S is pressed 
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("ForwardAnimation");
        }

        //if S is released
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetTrigger("ForwardAnimationPause");
        }

        //if D is pressed 
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("RightAnimatio");
        }

        //if D is released
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTrigger("RightAnimationPause");
        }

    }

    // Fixed frames unlike Update [Physics Calculation]
    private void FixedUpdate()
    {
        //makes our player move
        rigidBody.velocity = movementInput * moveSpeed;
    }

    //To get the Input System Clicks
    private void OnMove(InputValue inputValue)
    {
        // Converts WASD controls to Vector 2 values (X,Y)
        movementInput = inputValue.Get<Vector2>();
    }
}
