using UnityEngine;

/*
MADE BY : ADevNamedDeLL
Be sure to Subscribe to my YouTube Channel
*/

public class MouseLook : MonoBehaviour
{
    public float lookSpeed = 2.0f; // Sensitivity for mouse movement
    public float lookXLimit = 45.0f; // Limit for looking up and down

    private float rotationX = 0; // To store the vertical rotation

    public Transform playerBody; // The player's body for horizontal rotation
    public Camera playerCamera;  // The camera for vertical rotation

    [HideInInspector]
    public bool canLook = true; // Allows enabling/disabling look controls

    void Start()
    {
        // Lock cursor to the screen's center and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (canLook)
        {
            // Handle vertical rotation (up and down)
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); // Clamp between look limits

            // Apply the vertical rotation to the camera
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            // Handle horizontal rotation (left and right)
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            playerBody.Rotate(Vector3.up * mouseX); // Rotate the player body horizontally
        }
    }
}