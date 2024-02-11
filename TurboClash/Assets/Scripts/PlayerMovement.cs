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

    bool isPlayer1 = gameObject.tag == "Player1";

   /*  // Speed
    if(isPlayer1){
        if (Input.GetKey(KeyCode.D) )
            rb.velocity += new Vector3(speed, 0, 0);

        if (Input.GetKey(KeyCode.A))
            rb.velocity += new Vector3(-speed, 0, 0);

        if (Input.GetKey(KeyCode.W))
            rb.velocity += new Vector3(0, 0, speed);

        if (Input.GetKey(KeyCode.S))
            rb.velocity += new Vector3(0, 0, -speed);
    }
    else{
        if (Input.GetKey(KeyCode.RightArrow) )
            rb.velocity += new Vector3(speed, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            rb.velocity += new Vector3(-speed, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            rb.velocity += new Vector3(0, 0, speed);

        if (Input.GetKey(KeyCode.DownArrow))
            rb.velocity += new Vector3(0, 0, -speed);
    }
 */
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

  
}

   
