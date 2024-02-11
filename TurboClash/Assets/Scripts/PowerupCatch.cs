using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCatch : MonoBehaviour
{

    public int type = 0; // 0 - turbo, 1 - super jump, 2 - super kick
    public float duration = 5f;
    public int stadiumWidth = 13;
    public int stadiumLength = 8;

    private GameObject player1;
    private GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnTriggerEnter(Collider other)
    {
        bool isPlayer1 = other.gameObject.tag == "Player1";
        bool isPlayer2 = other.gameObject.tag == "Player2";

        if(isPlayer1 || isPlayer2)
        {
            if(type == 0) addTurbo(isPlayer1);
            else if(type == 1) addSuperJump(isPlayer1);
            else if (type == 2) addSuperKick(isPlayer1);
            else return; // invalid power-up type
            spawnNewPowerup();
        }
    }

    private void addTurbo(bool isPlayer1)
    {
        Debug.Log("Player " + (isPlayer1? "1" : "2") + " caught a turbo!");
        if(isPlayer1)
        {
            player1.gameObject.GetComponent<Rigidbody>().velocity *= 3;
            // TODO: set a timer to reset the speed
        }
        else
        {
            player2.gameObject.GetComponent<Rigidbody>().velocity *= 3;
            // TODO: set a timer to reset the speed
        }
    }

    private void addSuperJump(bool isPlayer1)
    {
        Debug.Log("Player " + (isPlayer1? "1" : "2") + " caught a super jump!");
        if(isPlayer1)
        {
            player1.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 8000, ForceMode.Impulse);
            // TODO: set a timer to reset the jump force
        }
        else
        {
            player2.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 8000, ForceMode.Impulse);
            // TODO: set a timer to reset the jump force
        }
    }

    private void addSuperKick(bool isPlayer1)
    {
        Debug.Log("Player " + (isPlayer1? "1" : "2") + " caught a super kick!");
        if(isPlayer1)
        {
            // player1.gameObject.GetComponent<Rigidbody>().AddForce(direction * playerSpeed * 20, ForceMode.Impulse);
            // TODO: set a timer to reset the kick force
        }
        else
        {
            // player2.gameObject.GetComponent<Rigidbody>().AddForce(direction * playerSpeed * 20, ForceMode.Impulse);
            // TODO: set a timer to reset the kick force
        }
    }

    private void spawnNewPowerup()
    {
        // Spawn a power-up at a new location
        float newX = Random.Range(-stadiumWidth, stadiumWidth);
        float newY = transform.position.y;
        float newZ = Random.Range(-stadiumLength, stadiumLength);
        Vector3 newPos = new Vector3(newX, newY, newZ);

        type = Random.Range(0, 3);

        GameObject powerup = Instantiate(gameObject, newPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
