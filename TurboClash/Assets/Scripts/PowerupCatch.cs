using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCatch : MonoBehaviour
{

    public enum Type{ Turbo, BallAttract, SuperKick}
    public Type type;
    public int stadiumWidth = 13;
    public int stadiumLength = 8;

    private GameObject player1;
    private GameObject player2;

    public AudioSource powerupSound;

    public CenterInfoController centerInfoController;

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
            else if(type == Type.BallAttract) addBallAttract(isPlayer1);
            else if (type == Type.SuperKick) addSuperKick(isPlayer1);
            else return; // invalid power-up type
            spawnNewPowerup();
        }
    }

    private IEnumerator TurboCoroutine(Rigidbody playerRigidbody)
    {
        float elapsedTime = 0f;
        float originalSpeed = playerRigidbody.velocity.magnitude;

        while (elapsedTime < 2f) 
        {
            float t = elapsedTime / 2f; 

            playerRigidbody.velocity = Vector3.ClampMagnitude(Vector3.Lerp(playerRigidbody.velocity, playerRigidbody.velocity * 3f, t), 14);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // After 2 seconds, reset the speed to the original magnitude
        playerRigidbody.velocity = playerRigidbody.velocity.normalized * originalSpeed;
    }

    private void addTurbo(bool isPlayer1)
    {
        Debug.Log("Player " + (isPlayer1 ? "1" : "2") + " caught a turbo!");
        Rigidbody playerRigidbody = isPlayer1 ? player1.GetComponent<Rigidbody>() : player2.GetComponent<Rigidbody>();

        centerInfoController.ShowMessage("Turbo!", 1f);

        StartCoroutine(TurboCoroutine(playerRigidbody));
    }

    private void addBallAttract(bool isPlayer1)
    {
        Debug.Log("Player " + (isPlayer1? "1" : "2") + " caught a ball attract");
        
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        if (ball != null)
        {
            centerInfoController.ShowMessage("Ball Attract!", 1f);
            float attractForce = 22.5f;

            Vector3 direction = isPlayer1 ? (player1.transform.position - ball.transform.position) : 
                                            (player2.transform.position - ball.transform.position);

            ball.GetComponent<Rigidbody>().AddForce(direction.normalized * attractForce, ForceMode.Impulse);

            Invoke("StopBallAttract", 2f);
        }
    }

    private void StopBallAttract()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
         ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void addSuperKick(bool isPlayer1)
    {
        Debug.Log("Player " + (isPlayer1? "1" : "2") + " caught a super kick!");
        if(isPlayer1)
        {
            // ...
        }
        else
        {
           // ...
        }
    }

    private void spawnNewPowerup()
    {
        // Spawn a power-up at a new location
        float newX = Random.Range(-stadiumWidth, stadiumWidth);
        float newY = transform.position.y;
        float newZ = Random.Range(-stadiumLength, stadiumLength);
        Vector3 newPos = new Vector3(newX, newY, newZ);

        type = (Type)Random.Range(0, 2);

        // instantiate the new power-up
        GameObject newPowerup = Instantiate(gameObject, newPos, Quaternion.identity);
        newPowerup.GetComponent<PowerupCatch>().type = type;

        // destroy the old power-up
        Destroy(gameObject);
    }
}
