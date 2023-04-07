using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jump = 1f;

    public float inertia = 1f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        /*
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        */
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        /*
    
        //Debug.Log(x +" " +  z);
        
        // Class should have:
        // public float movementSpeed;
        public float movementLerpSpeed;
        Vector3 _currentMovement;

        
        // In update:
        Vector3 rawMovement = new Vector3(move.x, 0.0f, move.y);
        _currentMovement = Vector3.MoveTowards(_currentMovement, rawMovement, movementLerpSpeed * Time.deltaTime);

        Vector3 finalMovement = transform.TransformVector(_currentMovement);
        controller.Move(finalMovement * speed * Time.deltaTime);
        */
        /*
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(inertia * velocity * Time.deltaTime);
        
        */
    }
}