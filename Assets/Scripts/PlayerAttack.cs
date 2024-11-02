using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private GameObject SubtractHitbox;

    [SerializeField]private GameObject AttackHitbox;
    private int currentWeapon = 0;


    private IEnumerator Attack() {
        
        if(currentWeapon == 0) {
            SubtractHitbox.SetActive(true);
            yield return new WaitForSeconds(1f);
            SubtractHitbox.SetActive(false);
        }
        else if(currentWeapon == 1) {
            AttackHitbox.SetActive(true);
            yield return new WaitForSeconds(1f);
            AttackHitbox.SetActive(false);
        }
        
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Attack());
        }
    }
}
