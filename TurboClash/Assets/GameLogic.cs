using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public int score1 = 0;
    public int score2 = 0;

    public GameObject player1;
    public GameObject player2;

    public GameObject ball;

    [ContextMenu("incrementScore")]
    public void incrementScore(int player, int amount){
        if (player == 1){
            score1 += amount;
        }
        else if (player == 2){
            score2 += amount;
        }
    }  

    [ContextMenu("respawnBall")]
    public void respawnBall()
    {
        // Spawn a new ball
        GameObject newBall = spawnBall();
        Destroy(ball);
        ball = newBall;
    }

    private GameObject spawnBall(){
       return Instantiate(ball, new Vector3(0, 0.5f, 0), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        ball = spawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
