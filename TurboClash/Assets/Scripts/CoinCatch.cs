using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCatch : MonoBehaviour
{

    private GameLogic gameLogic;
    public int stadiumWidth = 13;
    public int stadiumLength = 8;

    public AudioSource coinSound;

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

            coinSound.Play();
           
            gameLogic.incrementScore(other.gameObject.tag == "Player1"? 1: 2, 1);

            Debug.Log(other.gameObject.tag == "Player1"? "Player 1 caught a coin!" : "Player 2 caught a coin!");
            
            spawnNewCoin();
        }
    }

    void spawnNewCoin()
    {
        // Spawn a coin at a new location
        float newX = Random.Range(-stadiumWidth, stadiumWidth);
        float newY = transform.position.y;
        float newZ = Random.Range(-stadiumLength, stadiumLength);
        Vector3 newPos = new Vector3(newX, newY, newZ);

        GameObject coin = Instantiate(gameObject, newPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
