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
    if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270){
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

    void faceCamBall(){

    float rotationSpeed = 15f;
    float distanceBehind = 3f;
    float heightAbove = 1f;
    float smoothTime = 0.5f;
    Vector3 cameraVelocity = Vector3.zero;

    // Update camera position to follow both player and ball
    ball = GameObject.FindGameObjectWithTag("Ball");
    if (ball != null)
    {
        Vector3 lookDirection = ball.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        playerCamera.transform.rotation = Quaternion.RotateTowards(playerCamera.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Calculate the desired camera position
        Vector3 targetPosition = transform.position - playerCamera.transform.forward * distanceBehind + Vector3.up * heightAbove;

        // Smoothly move the camera towards the target position
        playerCamera.transform.position = Vector3.SmoothDamp(playerCamera.transform.position, targetPosition, ref cameraVelocity, smoothTime);
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


    public void Move(float inputHorizontal, float inputVertical){
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

   
