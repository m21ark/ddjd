using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfGoal : MonoBehaviour
{

    private GameLogic gameLogic;
    public bool isPlayer1 = false;

    public ParticleSystem goalExplosion;

    public AudioSource goalSound;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ball")
        {

            // goalSound.Play();

            float x = other.gameObject.transform.position.x;
            Debug.Log("Ball position: " + x);

            if (x > 0)
            {
                Debug.Log( "Player 2 scored!");
                gameLogic.incrementScore(2, 5);
            }
            else
            {
                Debug.Log( "Player 1 scored!");
                gameLogic.incrementScore(1, 5); 
            }

            gameLogic.respawnBall();

            // run the explosion on the position the ball has
            if(goalExplosion){
                goalExplosion.transform.position = other.gameObject.transform.position;
                goalExplosion.Play();
            }
            

        }
    }
}
