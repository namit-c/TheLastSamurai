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
    public bool isFacingRight = true;
    
    private float nextMoveTime = 0f;
    private float cooldown = 1;
    private float lastJump;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jumpButton;

    private Transform _originalParent;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if(Time.time >= nextMoveTime){

            if (Input.GetKey(left))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                horizontal = -1f;
            }
            else if (Input.GetKey(right))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                horizontal = 1f;
            }

            else if (Input.GetKeyUp(right) || Input.GetKeyUp(left))
            {
                animator.SetBool("Attack", true);
                AttackAfterMove();
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Input.GetKey(jumpButton))
            {

                if (Time.time - lastJump < cooldown)
                {
                    return;
                }
                lastJump = Time.time;
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                
            }

            if (Input.GetKeyUp(jumpButton) && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
                AttackAfterJump();
            }
            Flip(horizontal);
            horizontal = 0f;
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
        animator.SetBool("Attack", false);
    }

    private void Flip(float horizontal)
    {
        print("is facing right: " + isFacingRight + "; horizontal: " + horizontal);
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            print("scale: " + localScale);
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void SetParent(Transform newParent)
    {
        _originalParent = transform.parent;
        transform.parent = newParent;
    }

    public void ResetParent()
    {
        transform.parent = _originalParent;
    }

}
