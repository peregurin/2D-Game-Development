using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        moveInHorizontalDirection();
        moveInVerticalDirection();
    }

    private void moveInHorizontalDirection()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed * 0.5f));

        bool run = Input.GetKey(KeyCode.LeftShift);
        if (run)
        {
            animator.SetFloat("Speed", Mathf.Abs(speed));
        }

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void moveInVerticalDirection()
    {
        bool jump = Input.GetKeyDown(KeyCode.Space);
        animator.SetBool("Jump", jump);

        bool crouch = Input.GetKeyDown(KeyCode.C);
        animator.SetBool("Crouch", crouch);

        bool death = Input.GetKeyDown(KeyCode.V);
        animator.SetBool("Death", death);

        bool hurt = Input.GetKeyDown(KeyCode.H);
        animator.SetBool("Hurt", hurt);

        bool push = Input.GetKeyDown(KeyCode.P);
        animator.SetBool("Push", push);
    }

}
