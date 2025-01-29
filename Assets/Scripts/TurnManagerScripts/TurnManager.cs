using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum TurnState {PlayerTurn, EnemyTurn};
    public TurnState currentTurn = TurnState.PlayerTurn;
    public PC player;
    public List<EnemyController> enemies = new List<EnemyController>();

    void Start()
    {
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop(){
        while(true){
            if (currentTurn == TurnState.PlayerTurn){
                Debug.Log("Player's turn.");
                yield return StartCoroutine(PlayerTurn());
            }
            else if (currentTurn == TurnState.EnemyTurn){
                Debug.Log("Enemy's turn.");
                yield return StartCoroutine(EnemyTurn());

            }
        }
    }

    IEnumerator PlayerTurn(){
        player.StartTurn(); //Player can only act after this
        yield return new WaitUntil(() => player.hasMoved); //wait for player to move
        player.hasMoved = false; //reset movement flag








        currentTurn = TurnState.EnemyTurn;
    }


    IEnumerator EnemyTurn(){
        foreach(var enemy in enemies){
            enemy.TakeTurn();
            yield return new WaitForSeconds(1f); //wait time between enemy turns
        }
        currentTurn = TurnState.PlayerTurn;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
