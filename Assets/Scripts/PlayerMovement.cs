using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AttackMechanics attackMechanics;
    public Animator animator;
    public float moveCooldown;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public float attackRange1;
    public float attackRange2;

    private float speed = 8f;
    private float horizontal;
    private bool jump = true;
    private Rigidbody2D rb;
    public float movementRate = 2f;
    private float jumpingPower = 24f;
    private bool isFacingRight = true;

    private float nextMoveTime = 0f;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jumpButton;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if(Time.time >= nextMoveTime){

            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
                AttackAfterMove();
            }


            if (Input.GetKeyUp(right) || Input.GetKeyUp(left))
            {
                AttackAfterMove();
                animator.SetFloat("Speed", Mathf.Abs(speed));
            }

            Flip();
        }
    }

    public void AttackAfterMove(){
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
        attackMechanics.Attack(attackPoint2, attackRange2);
    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
