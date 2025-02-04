using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{

    public Tilemap tilemap;
    public float moveSpeed = 5f;
    private Vector3Int currentCell;
    private Vector3 targetPosition;

    void Start(){
        currentCell = tilemap.WorldToCell(transform.position);
        targetPosition = tilemap.CellToWorld(currentCell);
    }

    public void Move(Vector2 direction){
        Vector3Int moveDirection = new Vector3Int(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y), 0);
        Vector3Int newCell = currentCell + moveDirection;

        if (true){ //change this to make sure the player is on a valid tilemap
            targetPosition = tilemap.CellToWorld(newCell);
            currentCell = newCell;

            StartCoroutine(MoveToTarget(targetPosition));
        } 
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition){
        while(Vector3.Distance(transform.position, targetPosition) > 0.1f){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }
}
