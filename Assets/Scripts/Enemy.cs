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
    public string health = "20";
    private Rigidbody2D rb2D;
    public float moveTime = 0.1f;       //Time it will take object to move, in seconds.

    private float inverseMoveTime;      //Used to make movement more efficient.
    
    private bool enemyTurn;

    public GameObject projectilePrefab;

    public LayerMask enemyLayer;



    void OnEnable()
    {
        PlayerMovement.OnPlayerMoved += TakeTurn;
        PlayerAttack.OnPlayerAttacked += TakeTurn;
    }

    void OnDisable()
    {
        PlayerMovement.OnPlayerMoved -= TakeTurn;
        PlayerAttack.OnPlayerAttacked -= TakeTurn;
    
    }




    void Start()
    {
        rb2D = GetComponentInChildren<Rigidbody2D>();
        inverseMoveTime = 1 / moveTime;
        healthText = GetComponentInChildren<TMP_Text>();
        healthText.text = health.ToString();
        this.enabled = false;
    }
   
    public void ChangeHealth(string attack)
    {
        ExpressionTree tree = new ExpressionTree();
        tree.BuildFromInfix(health+attack);
        tree.InorderTraversal();
        health = tree.Evaluate().ToString();
        UpdateHealth();
    }

    public void UpdateHealth(){
        if(health == "0") {
            Destroy(gameObject);
            RewardManager.Instance.EnemyKilled();
        } else {
            healthText.text = health;
        }
    }

    
    void TakeTurn(Vector2 playerPosition)
    {
        enemyTurn =  true;
        if(enemyTurn)
        {
            Move(playerPosition);
        }
        if(enemyTurn)
        {
            Attack(playerPosition);
        }
    }

    void Move(Vector2 playerPosition) {
       
        if(Vector2.Distance((Vector2)transform.position, playerPosition) < 8)
        {
            RaycastHit2D enemyHit;
            
            float xDif = transform.position.x - playerPosition.x;
            float yDif = transform.position.y - playerPosition.y;
            if(Mathf.Abs(xDif) > 2 || Mathf.Abs(yDif) > 2) // is away from player
            {
                enemyTurn = false;
                if(Mathf.Abs(xDif)> Mathf.Abs(yDif) )
                {
                    if(xDif>=0)
                    {
                        //this is left movement
                        Vector2 start = transform.position;
                        Vector2 end = new Vector2(-1, 0);
                        enemyHit = Physics2D.Linecast(start, end, enemyLayer);
                        if(enemyHit.transform == null)
                        {
                            StartCoroutine(SmoothMovement(new Vector3(transform.position.x-1, transform.position.y, 0)));
                        }
                       
                    }
                    else{
                        Vector2 start = transform.position;
                        Vector2 end = new Vector2(1, 0);
                        enemyHit = Physics2D.Linecast(start, end, enemyLayer);
                        if(enemyHit.transform == null)
                        {
                            StartCoroutine(SmoothMovement(new Vector3(transform.position.x+1, transform.position.y, 0)));
                        }
                    }
                    
                }
                else {
                    if(yDif>=0)
                    {
                        Vector2 start = transform.position;
                        Vector2 end = new Vector2(0, -1);
                        enemyHit = Physics2D.Linecast(start, end, enemyLayer);
                        if(enemyHit.transform == null)
                        {
                            StartCoroutine(SmoothMovement(new Vector3(transform.position.x, transform.position.y-1, 0)));
                        }
                    }
                    else
                    {
                        Vector2 start = transform.position;
                        Vector2 end = new Vector2(0, 1);
                        enemyHit = Physics2D.Linecast(start, end, enemyLayer);
                        if(enemyHit.transform == null)
                        {
                            StartCoroutine(SmoothMovement(new Vector3(transform.position.x, transform.position.y+1, 0)));
                        }
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
        rb2D.bodyType = RigidbodyType2D.Dynamic;
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
        rb2D.bodyType = RigidbodyType2D.Static;
        //isPlayerMoving = false;
    }


    void Attack(Vector2 playerPosition)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 velocity = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);

        projectile.GetComponent<Projectile>().FireProjectile(velocity, this.gameObject);
    }

}
