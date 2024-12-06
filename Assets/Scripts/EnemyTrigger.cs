using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{  
    private Enemy enemy;
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            enemy.enabled = true;
        }
    }
}
