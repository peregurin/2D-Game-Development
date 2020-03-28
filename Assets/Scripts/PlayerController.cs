using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed;
    public float jumpForce;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        horizontalCharacterAnimation(horizontal);
        verticalCharacterAnimation(jump);
        moveInHorizontalDirection(horizontal);
        moveInVerticalDirection(jump);
    }

    private void moveInHorizontalDirection(float horizontal)
    {
        Vector3 position = transform.position;
        float runSpeed = walkSpeed + 4f;
        //Debug.Log(runSpeed);
        position.x += horizontal * (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed) * Time.deltaTime;
        transform.position = position;
    }

    private void moveInVerticalDirection(bool jump)
    {
        if (jump)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void horizontalCharacterAnimation(float horizontal)
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        bool run = Input.GetKey(KeyCode.LeftShift);
        if (run)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }else
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal * 0.5f));
        }

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void verticalCharacterAnimation(bool jump)
    {
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
