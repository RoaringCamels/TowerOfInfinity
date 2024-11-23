using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    //things the enemy needs
    //health
    //functions that change the "format" it's displayed in, depending on what type of number it is  
    //text for health
    private TMP_Text healthText;
    private float health = 20;
    private Rigidbody2D rb2D;
    public float moveTime = 0.1f;       //Time it will take object to move, in seconds.

    private float inverseMoveTime;      //Used to make movement more efficient.


    void OnEnable()
    {
        PlayerMovement.OnPlayerMoved += Move;
    }

    void OnDisable()
    {
        PlayerMovement.OnPlayerMoved -= Move;
    }



    void Start()
    {
        healthText = GetComponentInChildren<TMP_Text>();
        UpdateHealth();
        rb2D = GetComponentInChildren<Rigidbody2D>();
        inverseMoveTime = 1 / moveTime;
        transform.position = new Vector3(8, 4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubtractDamage(float damage)
    {
        health -= damage;
        UpdateHealth();
    }

    public void AddDamage(float damage) {
        health += damage;
        UpdateHealth();
    }

    public void DivideDamage(float quotient) {
        health = health / quotient;
        UpdateHealth();
    }


    void UpdateHealth(){
        if(health != 0) {
            healthText.text = health.ToString();
        } else {
            Destroy(gameObject);
        }
    }

    
    void Move(Vector2 playerPosition) {
        if(Vector2.Distance((Vector2)transform.position, playerPosition) < 8)
        {
            float xDif = transform.position.x - playerPosition.x;
            float yDif = transform.position.y - playerPosition.y;
            if(Mathf.Abs(xDif) > 2 || Mathf.Abs(yDif) > 2) // is away from player
            {
                if(Mathf.Abs(xDif)> Mathf.Abs(yDif) )
                {
                    if(xDif>=0)
                    {
                        StartCoroutine(SmoothMovement(new Vector3(transform.position.x-1, transform.position.y, 0)));
                    }
                    else{
                        StartCoroutine(SmoothMovement(new Vector3(transform.position.x+1, transform.position.y, 0)));
                    }
                    
                }
                else {
                    if(yDif>=0)
                    {
                        StartCoroutine(SmoothMovement(new Vector3(transform.position.x, transform.position.y-1, 0)));
                    }
                    else
                    {
                        StartCoroutine(SmoothMovement(new Vector3(transform.position.x, transform.position.y+1, 0)));
                    }
                }
            }
        }

    }

    protected IEnumerator SmoothMovement (Vector3 end)
    {
        
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        //isPlayerMoving = true;
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while(sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector2 newPostion = Vector2.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);

            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2D.MovePosition (newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
        //isPlayerMoving = false;
    }

}
