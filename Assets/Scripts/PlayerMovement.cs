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
    private float cooldown = 1;
    private float lastJump;

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

            if (Input.GetKeyUp(right) || Input.GetKeyUp(left))
            {
                animator.SetBool("Attack", true);
                AttackAfterMove();
            }

            if (Input.GetButtonDown("Jump"))
            {

                if (Time.time - lastJump < cooldown)
                {
                    return;
                }
                lastJump = Time.time;
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
                AttackAfterJump();
            }
            Flip();
        }
    }

    public void AttackAfterMove(){
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
        attackMechanics.Attack(attackPoint2, attackRange2);
    }

    public void AttackAfterJump()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
        attackMechanics.Attack(attackPoint2, attackRange2);
        animator.SetBool("IsJumping", false);

    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetBool("Attack", false);

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
