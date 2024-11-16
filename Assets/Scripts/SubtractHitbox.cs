using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractHitbox : MonoBehaviour
{
    PlayerAttack playerAttack;

    void Start() {
        playerAttack = GetComponent<PlayerAttack>();
    }
    void OnTriggerEnter2D(Collider2D other) {
                          
        if(other.CompareTag("Enemy")) {
            //deal whatever amount of damage
            other.gameObject.GetComponent<Enemy>().SubtractDamage(5f);
        }
        //instead of just destroying, perform the corresponding sword attack damage
    }

}
