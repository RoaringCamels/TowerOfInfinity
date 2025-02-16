using UnityEngine;

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

    public void StartTurn()
    {
        hasMoved = false;
    }

    void Update()
    {
        // Uncomment this line when you want to use turn management
        // if (!hasMoved && tm.currentTurn == TurnManager.TurnState.PlayerTurn)
        if (true)
        {
            if (Input.GetKeyDown(KeyCode.W)) { Debug.Log("UP"); TryMove(Vector2.up); }
            if (Input.GetKeyDown(KeyCode.A)) { Debug.Log("LEFT"); TryMove(Vector2.left); }
            if (Input.GetKeyDown(KeyCode.S)) { Debug.Log("DOWN"); TryMove(Vector2.down); }
            if (Input.GetKeyDown(KeyCode.D)) { Debug.Log("RIGHT"); TryMove(Vector2.right); }
        }
    }

    void TryMove(Vector2 direction)
    {
        if (pm.Move(direction))
        {
            hasMoved = true;
        }
    }
}