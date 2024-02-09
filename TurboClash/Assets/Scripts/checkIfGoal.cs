using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfGoal : MonoBehaviour
{

    private GameLogic gameLogic;
    public bool isPlayer1 = false;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Ball"){
            Debug.Log(isPlayer1? "Player 1 scored!" : "Player 2 scored!");

            gameLogic.incrementScore(isPlayer1? 1: 2, 5);
            gameLogic.respawnBall();
        }
    }
}
