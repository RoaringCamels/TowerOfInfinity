using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    private Rigidbody2D rb;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x+1, transform.position.y);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x-1, transform.position.y);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+1);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y-1);
        }
    }
}
