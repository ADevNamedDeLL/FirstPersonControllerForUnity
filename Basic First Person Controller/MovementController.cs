using UnityEngine;

/*
MADE BY : ADevNamedDeLL
Be sure to Subscribe to my YouTube Channel
*/

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed at which the player moves
    public float jumpForce = 7.0f; // Force applied when jumping
    public float gravityScale = 3.0f; // Scale to modify the gravity effect

    private CharacterController controller; // Reference to the CharacterController component
    private Vector3 moveDirection; // Movement direction

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component
        if (controller == null)
        {
            Debug.LogError("CharacterController component is missing from this GameObject.");
        }
    }

    void Update()
    {
        if (controller == null) return;

        // Get input for horizontal and vertical movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        moveDirection.x = move.x * moveSpeed;
        moveDirection.z = move.z * moveSpeed;

        // Apply gravity
        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;

        // Jumping
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        // Move the player
        controller.Move(moveDirection * Time.deltaTime);
    }
}