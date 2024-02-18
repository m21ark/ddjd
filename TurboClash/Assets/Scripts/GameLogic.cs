using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{

    public int score1 = 0;
    public int score2 = 0;

    public GameObject player1;
    public GameObject player2;
    public GameObject ball;


    private float gameTime = 0.0f;

    // =================== UI =====================

    public MenuController pauseMenuControl;

    public TextMeshProUGUI hud_score;
    public TextMeshProUGUI hud_speed1;
    public TextMeshProUGUI hud_speed2;
    public TextMeshProUGUI hud_timer;

    public TextMeshProUGUI endMenu_info;
    public GameObject endMenu;
    public GameObject hud;


    // function that resets players position
    [ContextMenu("resetPlayers")]
    public void resetPlayers(){

        // reset players position
        player1.transform.position = new Vector3(10.0f, 0f, 0.0f);
        player2.transform.position = new Vector3(-10.0f, 0f, 0.0f);

        // reset players velocity
        player1.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        player2.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);

        // reset players rotation
        player1.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        player2.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

        // reset angular velocity
        player1.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        player2.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
   

    [ContextMenu("incrementScore")]
    public void incrementScore(int player, int amount){
        if (player == 1) score1 += amount;
        else if (player == 2)  score2 += amount;

        if(amount >  1)
            resetPlayers();
        // else its a coin
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
       return Instantiate(ball, new Vector3(0.0f, 3.0f, 0.0f), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        ball = spawnBall();
        Time.timeScale = 1;
        gameTime = 0.0f;
    }

    // Update is called once per frame
    void Update(){

        // Check if ESC is pressed to pause Game
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseMenuControl.TogglePauseGame();
        
        // Update the game time
        gameTime += Time.deltaTime;

        updateHUD();

        if (score1 >= 10 || score2 >= 10 || gameTime >= 180) triggerEndOfGame();
    }

    [ContextMenu("TriggerEndOfGame")]
    public void triggerEndOfGame(){
        endMenu.SetActive(true);
        hud.SetActive(false);
        Time.timeScale = 0;

        string winner = (score1 > score2) ? "Player 1 wins" : "Player 2 wins";
        if (score1 == score2) winner = "It's a tie";
        endMenu_info.text = winner + "\n" + score1 + " - " + score2 + "\nTime: " + hud_timer.text;
    }

    void updateHUD(){
        hud_score.text = score1 + " | " + score2;

        int speed = (int) (player1.GetComponent<Rigidbody>().velocity.magnitude * 8.0f);
        hud_speed1.text =  speed.ToString() + "km/h";

        if(hud_speed2 != null){
            speed = (int) (player2.GetComponent<Rigidbody>().velocity.magnitude * 8.0f);
            hud_speed2.text =  speed.ToString() + "km/h";
        }
        
        // Timer in the format MM:SS
        int minutes = Mathf.FloorToInt((180 - gameTime )/ 60F);
        int seconds = Mathf.FloorToInt((180 - gameTime) - minutes * 60);
        hud_timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

}
