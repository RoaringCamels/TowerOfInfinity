using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovementTest : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    private const string WALL_TAG = "Wall";

    private bool isMoving = false;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private float moveProgress = 0f;
    private Tilemap wallTilemap;

    void Start()
    {
        // Find the WALLS tilemap at start
        GameObject wallObject = GameObject.FindGameObjectWithTag(WALL_TAG);
        if (wallObject != null)
        {
            wallTilemap = wallObject.GetComponent<Tilemap>();
        }
        
        if (wallTilemap == null)
        {
            Debug.LogError("Wall tilemap not found! Make sure your WALLS tilemap has the 'Wall' tag.");
        }
    }

    void Update()
    {
        if (!isMoving)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            if (Input.GetKeyDown(KeyCode.W)) TryMove(Vector2.up);
            else if (Input.GetKeyDown(KeyCode.S)) TryMove(Vector2.down);
            else if (Input.GetKeyDown(KeyCode.A)) TryMove(Vector2.left);
            else if (Input.GetKeyDown(KeyCode.D)) TryMove(Vector2.right);
        }
        else
        {
            // Handle smooth movement between tiles
            moveProgress += Time.deltaTime * moveSpeed;
            moveProgress = Mathf.Min(moveProgress, 1f); // Clamp progress

            if (moveProgress >= 1f)
            {
                transform.position = targetPosition;
                isMoving = false;
                moveProgress = 0f;
            }
            else
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
            }
        }
    }

    private void TryMove(Vector2 direction)
    {
        Vector3 nextPosition = transform.position + new Vector3(direction.x, direction.y, 0f);
        if (wallTilemap == null) return;

        Vector3Int nextCell = wallTilemap.WorldToCell(nextPosition);

        // Check if there's a wall at the next position
        if (wallTilemap.GetTile(nextCell) == null)
        {
            startPosition = transform.position;
            targetPosition = nextPosition;
            isMoving = true;
            moveProgress = 0f;
        }
    }
}
