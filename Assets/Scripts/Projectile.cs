using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private string damage = "-2";
    private Rigidbody2D rb;

    private GameObject thisParent;

    
    private void setDamage(string playerHealth)
    {
        //ex. playerHeatlh is a positve integer
        // damage = "-" + (int)(Math.Random()*2*level) + level

        //ex. playerHeatlh is a negative integer
        // damage = "+" + (int)(Math.Random()*2*level) + level

        //ex. playerHealth is a fraction
        // damage = "*" + (int)(Math.Random()*2) + level -1;    50% chance to get the right denominator;

        // "/" is implemented by a boss.
    }

    public void FireProjectile(Vector2 velocity, GameObject parent)
    {  
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
        thisParent = parent;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerHealth>().ChangeHealth(other.gameObject.GetComponentInParent<PlayerHealth>().health + damage);
        }
        if(!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        
    }
}
