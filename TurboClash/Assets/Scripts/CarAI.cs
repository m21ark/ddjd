using UnityEngine;

public class CarAI : MonoBehaviour
{
    private GameObject ball;
    private Rigidbody rb;

    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    private Vector3 rivalGoal = new Vector3(16, 1, 0);
    private Vector3 ownGoal = new Vector3(-16, 1, 0);

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (ball == null)
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
            return; // Exit the FixedUpdate if the ball is not found yet
        }

        // Calculate the direction to the ball
        Vector3 directionToBall = ball.transform.position - transform.position;
        directionToBall.y = 0f;

        // Rotate the car to face the direction of the ball
        Quaternion targetRotation = Quaternion.LookRotation(directionToBall);
        targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0); // Preserve Y rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move the car towards the ball
        rb.velocity = transform.forward * moveSpeed;

        // Apply gravity
        rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);

        // Make the car lower speed when it's close to the ball
        if (Vector3.Distance(ball.transform.position, transform.position) < 5f)
        {
            rb.velocity *= 0.5f; // Reduce speed when close to the ball
        }

       /*  // Check if the ball is within goal-seeking range
        if (Vector3.Distance(ball.transform.position, rivalGoal) < 10f)
        {
            // Ensure the car focuses on the ball until very close to the goal
            if (Vector3.Distance(ball.transform.position, transform.position) > 5f)
            {
                // Rotate the car to face the direction of the rival's goal
                Vector3 directionToGoal = rivalGoal - transform.position;
                directionToGoal.y = 0f;
                targetRotation = Quaternion.LookRotation(directionToGoal);
                targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0); // Preserve Y rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // Move the car towards the rival's goal
                rb.velocity = transform.forward * moveSpeed;
            }
        }

         // Check if the ball is too close to its own goal
        if (Vector3.Distance(ball.transform.position, ownGoal) < 5f)
        {
            // Move towards the ball and kick it away from the own goal
            Vector3 directionToBallFromOwnGoal = ball.transform.position - ownGoal;
            directionToBallFromOwnGoal.y = 0f;
            targetRotation = Quaternion.LookRotation(directionToBallFromOwnGoal);
            targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0); // Preserve Y rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.velocity = transform.forward * moveSpeed;
        } */
    }
}
