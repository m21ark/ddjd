using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 1f;
    public float jump = 4f;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    bool isPlayer1 = gameObject.tag == "Player1";

    // Jump
    if (Input.GetKey(KeyCode.Space) && transform.position.y < 0.3f)
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);


    // If the player is upside down, flip them back up
    if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270){
        Debug.Log("Player is upside down");
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        rb.angularVelocity = Vector3.zero;
    }


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

   
