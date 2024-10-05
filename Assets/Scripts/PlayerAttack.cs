using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private GameObject AttackHitbox;

    private IEnumerator Attack() {
        AttackHitbox.SetActive(true);
        yield return new WaitForSeconds(1f);
        AttackHitbox.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Attack());
        }
    }
}
