using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool crouch;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        animator.SetFloat("Height", Mathf.Abs(verticalMove));
        animator.SetBool("IsGrounded", jump==true);

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }


    void FixedUpdate()
    {
        // move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
