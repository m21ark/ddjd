using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKickBall : MonoBehaviour
{
    public int kickForce = 3; // force to kick the ball

    public AudioSource kickSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if collision with player, kick the ball in the direction the player is facing
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2"){

            kickSound.Play();
            
            // Get the ball and player's rigidbodies
            Rigidbody ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>();
            Rigidbody player = collision.gameObject.GetComponent<Rigidbody>();

            if(ball == null || player == null) return;

            // Calculate the direction from the ball to the player
            Vector3 direction = ball.transform.position - collision.gameObject.transform.position;
            direction.Normalize();
            
            // Apply force to the ball, scaling it with the player's speed
            float playerSpeed = player.velocity.magnitude;
            ball.AddForce(direction * playerSpeed * kickForce, ForceMode.Impulse);
        }
    } 
}
