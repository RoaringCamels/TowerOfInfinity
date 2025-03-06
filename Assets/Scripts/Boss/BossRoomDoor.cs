using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoor : MonoBehaviour
{
    //test
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //activate new level generation + give player sword
            Debug.Log("Player entered the door!");
            GameManager.instance.LevelCompleted();
        }
    }
}
