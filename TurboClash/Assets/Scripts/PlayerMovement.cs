using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 1f;
    public float jump = 4f;
    public Camera playerCamera;

    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }


    // Update is called once per frame
    void Update()
    {

        bool isPlayer1 = gameObject.tag == "Player1";

        // Jump P1
        if (Input.GetKey(KeyCode.Space) && transform.position.y < 0.3f)
            if (isPlayer1)
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);

        // Jump P2
        if (Input.GetKey(KeyCode.Return) && transform.position.y < 0.3f)
            if (!isPlayer1)
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);

        // If the player is upside down, flip them back up
        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270)
        {
            Debug.Log("Player is upside down");
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            rb.angularVelocity = Vector3.zero;
        }



        faceCamBall();


        /* //Cam update
        ball = GameObject.FindGameObjectWithTag("Ball");
        Vector3 lookDirection = ball.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            playerCamera.transform.rotation = Quaternion.RotateTowards(playerCamera.transform.rotation, targetRotation, Time.deltaTime * 100f);

            // Make camera go down and behind the player (in the direction of the ball)
            Vector3 cameraOffset = -playerCamera.transform.forward * 5f + Vector3.up * 2f;
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, transform.position + cameraOffset, Time.deltaTime * 5f); */
    }

    void faceCamBall()
    {
        float distanceBehindCar = 5f; 
        float heightAboveCar = 2f; 

        GameObject car = GameObject.FindGameObjectWithTag(gameObject.tag);
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        if (car != null && ball != null)
        {
            Vector3 desiredPosition = car.transform.position - car.transform.forward * distanceBehindCar + Vector3.up * heightAboveCar;
            Vector3 carToBallDirection = ball.transform.position - car.transform.position;

            if (Vector3.Dot(car.transform.forward, carToBallDirection) < 0)
            {
                desiredPosition = car.transform.position + car.transform.forward * distanceBehindCar + Vector3.up * heightAboveCar;
            }

            Vector3 lookDirection = ball.transform.position - desiredPosition;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

            playerCamera.transform.position = desiredPosition;
            playerCamera.transform.rotation = targetRotation;

        }
    }




    void FixedUpdate()
    {
        // Move player based on input
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, 0.0f, inputVertical);
        rb.AddForce(movement * speed);
    }


    public void Move(float inputHorizontal, float inputVertical)
    {
        // Get the forward and right vectors of the camera
        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;

        // Project the camera vectors onto the horizontal plane (Y = 0)
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction based on camera orientation
        Vector3 moveDirection = cameraForward * inputVertical + cameraRight * inputHorizontal;
        rb.velocity = moveDirection * speed;
    }


}


