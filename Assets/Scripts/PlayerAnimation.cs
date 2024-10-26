using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   private PlayerMovement playerMovement;
   void Start()
   {
        playerMovement = GetComponent<PlayerMovement>();
   }
   public void ChangeDirection(int direction)
   {
        if(direction == 0)    // facing right
        {
            transform.localScale = new Vector2(1,1);
        }
        else if(direction == 1)    // facing left
        {
            transform.localScale = new Vector2(-1,1);
        }
   }
}
