using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerController : People
{
    private float Input_Horizontal;
    private float Input_Vertical;
    private float Walking_OR_Running_Speed;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputValue();
        Moving();
    }

    private void InputValue() {
        Input_Horizontal = Input.GetAxisRaw("Horizontal");
        Input_Vertical = Input.GetAxisRaw("Vertical");
        if (Input_Horizontal != 0 || Input_Vertical != 0) {
            animator.SetBool("IsRunning", true);
        }
        else {
            animator.SetBool("IsRunning", false);
        }
        animator.SetFloat("Horizontal", Input_Horizontal);
        animator.SetFloat("Vertical", Input_Vertical);

    }

    private void Moving() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            Walking_OR_Running_Speed = runningspeed;
        }
        else {
            Walking_OR_Running_Speed = walkingspeed;
        }
        if (Input_Horizontal != 0) {
            this.transform.Translate(Time.deltaTime * UnityEngine.Vector3.right * Input_Horizontal * Walking_OR_Running_Speed);
        }
        else if (Input_Vertical != 0) {
            this.transform.Translate(Time.deltaTime * UnityEngine.Vector3.up * Input_Vertical * Walking_OR_Running_Speed);
        }
        else {

        }
    }
}
