using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Trigger : MonoBehaviour
{
    private Bosslev1 boss;
    void Start()
    {
        boss = gameObject.GetComponent<Bosslev1>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //enemy.UpdateHealth();
            boss.enabled = true;
        }
    }
}
