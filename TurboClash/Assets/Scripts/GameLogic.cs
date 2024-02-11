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
    public TextMeshProUGUI hud_speed;
    public TextMeshProUGUI hud_timer;

    public TextMeshProUGUI endMenu_info;
    public GameObject endMenu;
    public GameObject hud;



    [ContextMenu("incrementScore")]
    public void incrementScore(int player, int amount){
        if (player == 1) score1 += amount;
        else if (player == 2)  score2 += amount;
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
        hud_speed.text =  speed.ToString() + "km/h";
        
        // Timer in the format MM:SS
        int minutes = Mathf.FloorToInt(gameTime / 60F);
        int seconds = Mathf.FloorToInt(gameTime - minutes * 60);
        hud_timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

}
