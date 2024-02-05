using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Animator animator;
    GameObject run;
    AudioSource runningSound;

    public float sprintSpeedMultiplier = 2.0f;
    private bool isSprinting;
    float moveX;
    float moveZ;

    void Awake()
    {
        run = GameObject.Find("/Sounds/RunningSound");
        runningSound = run.GetComponent<AudioSource>();
        
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        moveX = isSprinting ? Input.GetAxis("Horizontal") * moveSpeed * sprintSpeedMultiplier : Input.GetAxis("Horizontal") * moveSpeed;
        moveZ = isSprinting ? Input.GetAxis("Vertical") * moveSpeed * sprintSpeedMultiplier : Input.GetAxis("Vertical") * moveSpeed;

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        float inputMagnitude = movement.magnitude;

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if((Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) && !runningSound.isPlaying)
        {
            runningSound.Play();
        } else if( !Input.GetButton( "Horizontal" ) && !Input.GetButton( "Vertical" ) && runningSound.isPlaying)
        {
            runningSound.Pause();
        }

        if(movement != Vector3.zero)
        {
            //runningSound.Play();
            transform.forward = movement;
            animator.SetFloat("MoveForward", inputMagnitude);
            animator.SetFloat("SprintFactor", isSprinting ? 1.0f : 0.0f);
        }else{
            //runningSound.Stop();
            animator.SetFloat("MoveForward", 0);
            animator.SetFloat("SprintFactor", 0);
        }

    }

}