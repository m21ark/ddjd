using UnityEngine;

public class CarAI : MonoBehaviour
{
    private GameObject ball;
    private Rigidbody rb;

    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (ball != null)
        {
        // Calculate the direction to the ball
        Vector3 direction = ball.transform.position - transform.position;
        direction.y = 0f; // Ignore vertical difference

        // Rotate the car to face the direction of the ball
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0); // Preserve Y rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Apply gravity
        rb.AddForce(Vector3.down * 9.8f, ForceMode.Acceleration);

        // Move the car towards the ball
        rb.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);

        }else
            ball = GameObject.FindGameObjectWithTag("Ball");
        
    }
}
