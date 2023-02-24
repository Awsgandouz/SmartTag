using UnityEngine;

public class Player : MonoBehaviour
{
    // My Offsets
    [SerializeField] int meterToSpace = 20;
    [SerializeField] int x_offset = 20;
    [SerializeField] int z_offset = -20;

    // Player movement settings
    [SerializeField] float moveSpeed = 5f; // The speed at which the player moves
    [SerializeField] float rotateSpeed = 5f; // The speed at which the player rotates

    private float forwardMovement = 0f; // The amount of forward movement the player is doing
    private float strafeMovement = 0f; // The amount of strafe movement the player is doing
    private float rotation = 0f; // The amount of rotation the player is doing

    private void Update()
    {
        // Get the input for forward/backward and strafe movement
        forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        strafeMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Get the input for rotation
        rotation = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        // Rotate the player based on the input
        transform.Rotate(Vector3.up, rotation);

        // Move the player based on the input
        transform.Translate(strafeMovement, 0f, forwardMovement, Space.Self);
    }

    public void movePlayer(double x, double y)
    {
        if (double.IsNaN(x))
            x = 0;
        if (double.IsNaN(y))
            y = 0;

        transform.position = new Vector3((float)y * meterToSpace * -1 + x_offset, 0, (float)x * meterToSpace + z_offset);
    }
}

