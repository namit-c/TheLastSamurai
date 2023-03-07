using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public CharacterController2D_P2 controller;
    public AttackMechanics2 attackMechanics;
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

    public KeyCode left;
    public KeyCode right;
    public KeyCode jumpButton;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextMoveTime){

            if (Input.GetKey(right))
            {
                xSpeed = moveSpeed;
                AttackAfterMove();
            }
            if (Input.GetKey(left))
            {
                xSpeed = -moveSpeed;
                AttackAfterMove();
            }
            if (Input.GetKeyUp(right) || Input.GetKeyUp(left))
            {
                xSpeed = 0;
            }
            animator.SetFloat("Speed2", Mathf.Abs(xSpeed));

            // if(Input.GetAxisRaw("Horizontal") != 0){
            //     // if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            //     // {
            //     Debug.Log("test");
            //     AttackAfterMove();
            //     // }
            // }

            if(Mathf.Abs(xSpeed) > 0 || Input.GetKeyDown(jumpButton)){
                nextMoveTime = Time. time + 1f / movementRate;
            }

            // yInput = Input.GetAxis("Vertical");
            if(Input.GetKeyDown(jumpButton)){
                jump = true;
                animator.SetBool("IsJumping2", true);
                attackMechanics.Attack(attackPoint1, attackRange1);
            }
        }
    }
    
    public void AttackAfterMove(){
        attackMechanics.Attack(attackPoint2, attackRange2);
    }

    public void OnLanding(){
        animator.SetBool("IsJumping2", false);
    }

    void FixedUpdate(){

        controller.Move(xSpeed, false, jump);
        jump = false;
        xSpeed = 0f;

    }
}
