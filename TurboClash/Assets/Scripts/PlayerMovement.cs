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

    // Speed
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

    // Jump
    if (Input.GetKey(KeyCode.Space)){

        Debug.Log("SPACE BAR PRESSED!");

        if(transform.position.y < 0.3f){
                   Debug.Log("JUMPING!");

            // make an upward impulse force
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }else Debug.Log("CANT JUMP: " + transform.position.y.ToString());

        
    }
        

    // Make camera follow
    if(isPlayer1) makeCameraFollow();
    }

    void makeCameraFollow(){
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 8);
    }
}
