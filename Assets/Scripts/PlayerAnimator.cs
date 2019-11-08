using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("ForwardBack");
        Animator.SetFloat("Speed", speed);

        float strafe = Input.GetAxis("LeftRight");
        Animator.SetFloat("LeftRight", strafe);

        bool sprint = Input.GetButton("Sprint");
        Animator.SetBool("Run", sprint);

        if (Input.GetMouseButtonDown(0))
            Animator.SetTrigger("Attack");
    }
}
