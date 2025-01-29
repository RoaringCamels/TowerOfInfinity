using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PC : MonoBehaviour
{
    private PlayerMovement pm;
    private TurnManager tm;
    public bool hasMoved = false;

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        tm = FindObjectOfType<TurnManager>();
    }

    public void StartTurn(){
        hasMoved = false;
    }

    
    void Update()
    {
        if (!hasMoved && tm.currentTurn == TurnManager.TurnState.PlayerTurn){
            if (Input.GetKeyDown(KeyCode.W)) Move(Vector2.up);
            if (Input.GetKeyDown(KeyCode.A)) Move(Vector2.left);
            if (Input.GetKeyDown(KeyCode.S)) Move(Vector2.down);
            if (Input.GetKeyDown(KeyCode.D)) Move(Vector2.right);
        }

    }

    void Move(Vector2 direction){
        pm.Move(direction);
        hasMoved = true;
    }
}
