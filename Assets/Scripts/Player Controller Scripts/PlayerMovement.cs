using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask wallLayer;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private BoxCollider2D playerCollider;
    public Tilemap wallTilemap;

    void Start()
    {
        targetPosition = transform.position;
        playerCollider = GetComponent<BoxCollider2D>();

        if (wallTilemap == null)
        {
            Debug.LogError("Please assign the Wall Tilemap in the inspector!");
            return;
        }

        if (wallLayer.value == 0)
        {
            Debug.LogError("Wall Layer mask is not set!");
            return;
        }
    }

    // Public method that can be called from PC script
    public bool Move(Vector2 direction)
    {
        if (isMoving) return false;

        Vector3 input = new Vector3(direction.x, direction.y, 0);
        
        if (!IsWallBlocking(input))
        {
            targetPosition = transform.position + input;
            StartCoroutine(MoveToTarget());
            return true; // Movement was successful
        }
        else
        {
            Debug.Log("Movement blocked by wall!");
            return false; // Movement was blocked
        }
    }

    private bool IsWallBlocking(Vector3 direction)
    {
        Bounds bounds = playerCollider.bounds;
        Vector2 size = bounds.size;

        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            size * 0.95f,
            0f,
            direction,
            0.1f,
            wallLayer
        );

        if (hit.collider != null)
        {
            Debug.Log($"Wall detected: {hit.collider.gameObject.name}");
            return true;
        }

        Vector3Int cellPosition = wallTilemap.WorldToCell(transform.position + direction);
        if (wallTilemap.HasTile(cellPosition))
        {
            Debug.Log($"Wall tile detected at {cellPosition}");
            return true;
        }

        return false;
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        float moveTime = 1f / moveSpeed;

        while (elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveTime);
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }

    void OnDrawGizmos()
    {
        if (!playerCollider) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, playerCollider.bounds.size * 0.95f);

        if (isMoving)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(targetPosition, playerCollider.bounds.size);
        }
    }

    // Public method to check if the player is currently moving
    public bool IsMoving()
    {
        return isMoving;
    }
}