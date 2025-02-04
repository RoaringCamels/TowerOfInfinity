using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyController : MonoBehaviour
{
    public string enemyName;
    public string health;
    public int attackPower;
    public float moveSpeed;
    public bool hasMoved;
    private Vector3 targetPosition;
    public float attackRange = 1f;
    public PC player;

    private Tilemap tilemap;
    private Vector3Int currentCell;
    private Vector3Int targetCell;
    private Vector3 targetWorldPosition;
    private bool isMoving;

    public void Start(){
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();

        // Initialize enemy to start at a specific cell on the Tilemap
        currentCell = tilemap.WorldToCell(transform.position);
        targetCell = currentCell;
        targetWorldPosition = tilemap.CellToWorld(targetCell);
    }
    public void TakeTurn(){
        // Add agorithm so that it only does one of the two below
        MoveToPlayer();
        AttackPlayer();

        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange){
            AttackPlayer();
        }
        else{
            MoveToPlayer();
        }
    }

    public void StartTurn(){
        hasMoved = false;
    }


    public void MoveToPlayer(){
        Debug.Log("Calling MoveToPLayer().");
        if (isMoving) return;  // Prevent multiple movements at once.

        // Get the player's tile position (in tilemap coordinates)
        Vector3Int playerCell = tilemap.WorldToCell(player.transform.position);

        // Check if the current position is different from the player's position
        if (currentCell != playerCell)
        {
            // Calculate the direction towards the player
            Vector3Int direction = new Vector3Int(
                Mathf.Sign(playerCell.x - currentCell.x) > 0 ? 1 : Mathf.Sign(playerCell.x - currentCell.x) < 0 ? -1 : 0,  // Direction in x (1 for right, -1 for left)
                Mathf.Sign(playerCell.y - currentCell.y) > 0 ? 1 : Mathf.Sign(playerCell.y - currentCell.y) < 0 ? -1 : 0,  // Direction in y (1 for up, -1 for down)
            0);  // Assuming movement is in 2D, so z remains 0

            // Calculate the next tile in the direction of the player
            Vector3Int nextCell = currentCell + direction;

            // Move the enemy to the next tile in the direction of the player
            targetWorldPosition = tilemap.CellToWorld(nextCell);  // Convert the grid position to world space
            transform.position = targetWorldPosition;  // Move the enemy to the next tile

            // Update the current cell to the new position
            currentCell = nextCell;

            // Mark that the enemy has moved
            hasMoved = true;  // Indicate the enemy has finished its movement
        }
    }

    public void AttackPlayer(){
        Debug.Log("Calling AttackPlayer.");
    }
}
