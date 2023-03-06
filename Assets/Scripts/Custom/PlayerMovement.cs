using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public AttackMechanics attackMechanics;
    public Animator animator;
    public float moveSpeed;
    public float moveCooldown;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public float attackRange1;
    public float attackRange2;

    private float xSpeed;
    private bool jump = true;
    private float yInput;
    private Rigidbody2D rb;
    public float movementRate = 2f;
    private float nextMoveTime = 0f;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextMoveTime){
            
            xSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;
            animator.SetFloat("Speed", Mathf.Abs(xSpeed));

            if(Input.GetAxisRaw("Horizontal") != 0){
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    AttackAfterMove();
                }
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                attackMechanics.Attack(attackPoint2, attackRange2);
                animator.SetTrigger("Attack");
            }

            if(Mathf.Abs(xSpeed) > 0 || Input.GetKeyDown("up")){
                nextMoveTime = Time. time + 1f / movementRate;
            }

            // yInput = Input.GetAxis("Vertical");
            if(Input.GetKeyDown("up")){
                jump = true;
                animator.SetBool("IsJumping", true);
                attackMechanics.Attack(attackPoint1, attackRange1);
            }
        }
    }
    
    public void AttackAfterMove(){
        attackMechanics.Attack(attackPoint2, attackRange2);
    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate(){

        controller.Move(xSpeed, false, jump);
        jump = false;
        xSpeed = 0f;

    }
}
