using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PowerupEffect", menuName = "PowerupEffect/HealthBuff")]

public class HealthBuff : PowerupEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().currentHealth += amount;
    }
}

