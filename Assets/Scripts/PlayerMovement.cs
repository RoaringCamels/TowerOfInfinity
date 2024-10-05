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
            transform.position = new Vector2(transform.position.x + .16f, transform.position.y);
            print("D pressed!");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(transform.position.x -.16f >= -1.25){
                transform.position = new Vector2(transform.position.x-.16f, transform.position.y);
            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(transform.position.y +.16f <= .6f){
                transform.position = new Vector2(transform.position.x, transform.position.y+.16f);
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(transform.position.y -.16f >= -.8f){
                transform.position = new Vector2(transform.position.x, transform.position.y-.16f);
            }
            
        }
    }
}
