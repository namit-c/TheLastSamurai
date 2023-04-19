using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PowerupEffect", menuName = "PowerupEffect/AttackBuff")]

public class AttackBuff : PowerupEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<AttackMechanics>().attackDamage += amount;
    }
}

