using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractHitbox : MonoBehaviour
{
    PlayerAttack playerAttack;

    void Start() {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }
    void OnTriggerEnter2D(Collider2D other) {
                          
        if(other.CompareTag("Enemy")) {
            //deal whatever amount of damage
            
            print(other.gameObject.GetComponentInParent<Enemy>().health + playerAttack.performOperation());
            other.gameObject.GetComponentInParent<Enemy>().ChangeHealth(other.gameObject.GetComponentInParent<Enemy>().health + playerAttack.performOperation());
        }
        //instead of just destroying, perform the corresponding sword attack damage
    }

}
