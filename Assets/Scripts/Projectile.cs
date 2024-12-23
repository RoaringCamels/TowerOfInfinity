using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   
    private string damage;
    private float speed;
    private Rigidbody2D rb;


    public void FireProjectile(Vector2 velocity)
    {  
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }
}
