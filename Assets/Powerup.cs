using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Console.WriteLine("Hello" );
        powerupEffect.Apply(collision.gameObject);
    }

}
