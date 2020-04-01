using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public ScoreController scoreController;
    public float walkSpeed;
    public float jumpForce;

    private bool isGrounded = false;
    private int health = 3;

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

    public void PickUpKey()
    {
        Debug.Log("The player has picked up the key.");
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        Debug.Log("The player is dead");
        ReloadLevel();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void reduceHealth()
    {
        if (health > 0)
        {
            health--;
            Debug.Log("Health remaining: " + health);
        }
        else
        {
            KillPlayer();
        }
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
        if (jump && isGrounded)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("function called");
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("function called");
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }

}
