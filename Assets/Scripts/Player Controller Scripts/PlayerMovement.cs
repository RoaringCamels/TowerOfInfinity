using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void Move(Vector2 direction){
        transform.position +=(Vector3)direction;
    }
}
