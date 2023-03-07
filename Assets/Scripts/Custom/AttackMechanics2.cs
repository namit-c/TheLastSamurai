using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMechanics2 : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint1;
    public Transform attackPoint2;
    public float attackRange1;
    public float attackRange2;
    public float attackDamage = 10f;
    public LayerMask enemyLayer;

    public void Attack(Transform attackPoint, float attackRange){
        // More general; can expand to multiple enemies (maybe for training)
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        Debug.Log("enemies 2 length: " + hitEnemies.Length);

        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Player1>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint1 == null || attackPoint2 == null)
            return;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange1);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
    }
}
