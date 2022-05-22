using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerAnimSwitcher : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isBusted", false);
        animator.SetBool("isSlowedDown", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Acceleration") > 0)
        {
            animator.SetBool("isBusted", true);
        }
        else if (Input.GetAxisRaw("Acceleration") < 0)
        {
            animator.SetBool("isSlowedDown", true);
        }
        else
        {
            animator.SetBool("isBusted", false);
            animator.SetBool("isSlowedDown", false);
        }
    }
}
