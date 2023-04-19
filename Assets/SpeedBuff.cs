using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PowerupEffect", menuName = "PowerupEffect/SpeedBuff")]

public class SpeedBuff : PowerupEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().moveSpeed += amount;
    }
}

