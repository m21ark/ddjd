using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCatch : MonoBehaviour
{

    public enum Type{ Turbo, SuperJump, SuperKick}
    public Type type;
    public float duration = 5f;
    public int stadiumWidth = 13;
    public int stadiumLength = 8;

    private GameObject player1;
    private GameObject player2;

    public AudioSource powerupSound;

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
            powerupSound.Play();

            if(type == Type.Turbo) addTurbo(isPlayer1);
            else if(type == Type.SuperJump) addSuperJump(isPlayer1);
            else if (type == Type.SuperKick) addSuperKick(isPlayer1);
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

        type = (Type)Random.Range(0, 3);

        // instantiate the new power-up
        GameObject newPowerup = Instantiate(gameObject, newPos, Quaternion.identity);
        newPowerup.GetComponent<PowerupCatch>().type = type;

        // destroy the old power-up
        Destroy(gameObject);
    }
}
