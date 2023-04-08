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

    public KeyCode left;
    public KeyCode right;
    public KeyCode jumpButton;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void Update()
    {
        if(Time.time >= nextMoveTime){

            if (Input.GetKey(right))
            {
                controller.Move(moveSpeed, false, jump);
                xSpeed = moveSpeed;

            }
            if (Input.GetKey(left))
            {
                controller.Move(-moveSpeed, false, jump);
                xSpeed = -moveSpeed;
            }
            if (Input.GetKeyUp(right) || Input.GetKeyUp(left))
            {
                xSpeed = 0;
                SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
                AttackAfterMove();
            }
            animator.SetFloat("Speed", Mathf.Abs(xSpeed));

            if(Mathf.Abs(xSpeed) > 0 || Input.GetKeyDown(jumpButton)){
                nextMoveTime = Time. time + 1f / movementRate;
            }

            if(Input.GetKeyDown(jumpButton)){
                SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);
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

        //controller.Move(xSpeed, false, jump);
        //jump = false;
        xSpeed = 0f;

    }
}
