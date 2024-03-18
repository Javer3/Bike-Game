using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Move the bike forward or backward
        rb.MovePosition(rb.position + transform.forward * verticalInput * speed * Time.fixedDeltaTime);

        // Rotate the bike left or right
        float rotation = horizontalInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
