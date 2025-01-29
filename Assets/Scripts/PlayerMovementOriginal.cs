using UnityEngine;

public class PlayerMovementOriginal : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed for moving between tiles
    private bool isMoving = false; // Prevent movement until current step finishes
    private Vector3 targetPosition; // The player's next tile position

    void Start()
    {
        // Start at the player's initial position
        targetPosition = transform.position;
    }

    void Update()
    {
        if (isMoving) return; // Prevent new input while moving

        // Get input for movement
        Vector3 input = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W)) input = Vector3.up;      // Up
        if (Input.GetKeyDown(KeyCode.S)) input = Vector3.down;    // Down
        if (Input.GetKeyDown(KeyCode.A)) input = Vector3.left;    // Left
        if (Input.GetKeyDown(KeyCode.D)) input = Vector3.right;   // Right

        if (input != Vector3.zero)
        {
            // Calculate target position based on grid
            targetPosition = transform.position + input;

            // Start movement coroutine
            StartCoroutine(MoveToTarget());
        }
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;

        // Move the player to the target position smoothly
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        // Snap to exact position to avoid rounding errors
        transform.position = targetPosition;

        isMoving = false; // Allow new movement
    }
}
