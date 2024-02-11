using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCatch : MonoBehaviour
{

    private GameLogic gameLogic;
    public int stadiumWidth = 40;
    public int stadiumLength = 70;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
           
            gameLogic.incrementScore(other.gameObject.tag == "Player1"? 1: 2, 1);

            Debug.Log(other.gameObject.tag == "Player1"? "Player 1 caught a coin!" : "Player 2 caught a coin!");

            // get old objects Y
            float oldY = transform.position.y;

            // Respawn the coin in a random position
            Vector3 newPos = new Vector3(Random.Range(-stadiumWidth, stadiumWidth), oldY, Random.Range(-stadiumLength, stadiumLength));
            GameObject coin = Instantiate(gameObject, newPos, Quaternion.identity);;
            Destroy(gameObject);
        }
    }
}
