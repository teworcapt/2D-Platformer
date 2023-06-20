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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("BackwardAnimation");
        }


        //if A is pressed 
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("LeftAnimation");
        }


        //if S is pressed 
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("ForwardAnimation");
        }

        //if D is pressed 
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("RightAnimatio");
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
        {
            anim.enabled = false;
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
