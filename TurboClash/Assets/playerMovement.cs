using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 1f;
    public float jump = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    // Speed
    if (Input.GetKey(KeyCode.D) )
        rb.velocity += new Vector3(speed, 0, 0);

    if (Input.GetKey(KeyCode.A))
        rb.velocity += new Vector3(-speed, 0, 0);

    if (Input.GetKey(KeyCode.W))
        rb.velocity += new Vector3(0, 0, speed);

    if (Input.GetKey(KeyCode.S))
        rb.velocity += new Vector3(0, 0, -speed);

    // Jump
    if (Input.GetKey(KeyCode.Space) && transform.position.y == 0.5f)
        // make an upward impulse force
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        

    // Make camera follow
    makeCameraFollow();
    }

    void makeCameraFollow(){
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 8);
    }
}
