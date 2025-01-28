using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Player Object")]
    public GameObject playerObject;
   private PlayerMovement playerMovement;
   void Start()
   {
        playerMovement = GetComponent<PlayerMovement>();
   }
   public void ChangeDirection(int direction)
   {
        if(direction == 0)    // facing right
        {
            playerObject.transform.localScale = new Vector2(-.8f, .7f);
        }
        else if(direction == 1)    // facing left
        {
            playerObject.transform.localScale = new Vector2(0.8f,.7f);
        }
   }
}
