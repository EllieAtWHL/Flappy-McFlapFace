using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour{
    public int playerScore;
    public int highScore;
    public int scoreRange = 5;
    public double moveSpeed = 4;
    public double increaseMultipler = 0.9;
    public bool birdIsAlive = false;
    public Text scoreText;
    public Text highScoreText;
    public GameObject startScreen;
    public GameObject bird;
    public GameObject gameOverScreen;
    public GameObject speedUpSound;
    public GameObject gameOverSound;

    void Start(){
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        updateHighScoreDisplay();
    }

    public void addScore(int scoreToAdd){
        playerScore += scoreToAdd;
        GetComponent<AudioSource>().Play();
        updateScoreDisplay();

        if(playerScore % scoreRange == 0){ 
            moveSpeed = moveSpeed * increaseMultipler;
            speedUpSound.GetComponent<AudioSource>().Play();
        }
    }

    void updateScoreDisplay(){
        scoreText.text = playerScore.ToString();
    }

    void updateHighScoreDisplay(){
        highScoreText.text = highScore.ToString();
    }

    public void gameOver(){
        gameOverSound.GetComponent<AudioSource>().Play();
        birdIsAlive = false;
        bird.SetActive(false);
        if(playerScore > highScore){
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore = playerScore;
            updateHighScoreDisplay();
        }
        gameOverScreen.SetActive(true);
    }

    public void startGame(){
        GameObject[] allPipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach(GameObject pipe in allPipes)
            Destroy(pipe);
        startScreen.SetActive(false);   
        playerScore = 0;
        updateScoreDisplay();
        bird.gameObject.transform.position = new Vector3(0, 0, 0);
        gameOverScreen.SetActive(false);
        bird.SetActive(true);
        birdIsAlive = true;
    }

    public void backToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame(){
        Application.Quit();
    }
}
