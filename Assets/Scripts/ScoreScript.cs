using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public bool gameOver;
    private bool isDead = false;

    public Text normalScore;
    public Text highScore;
    //public static ScoreScript instance;

    private int difficultyLevel = 10;
    //private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    public float score = 0;

    public Text scoreText;
    public DeathMenu deathMenu;
    // Start is called before the first frame update
    void Start()
    {

        //PlayerPrefs.SetInt("Score",(int)score);
        //PlayerPrefs.SetInt("NormalScore", (int)score);
        //score = 0;
        //highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
        //testingScore.text = "Test Score" + PlayerPrefs.GetInt("Score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            //deathMenu.gameObject.SetActive(true);
            return;
        }
      
        
            ScoreUpdate();
            ScoreCompare();
            
        
      

        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }
        //score += Time.deltaTime;
        //scoreText.text = ((int)score).ToString();
        //ToggleDeathMenu(score);
        normalScore.text = ((int)score).ToString();
    }

    public void ScoreUpdate()
    {
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        
        //if(difficultyLevel == maxDifficultyLevel)
        //{
        //    return;
        //}
        scoreToNextLevel *= 2;
        difficultyLevel += 10;
        //scoreToNextLevel = scoreToNextLevel * 2;
        GetComponent<PlayerController>().setSpeedDifficulty(difficultyLevel);
        //GetComponent<PlayerController>().onDeath();
        //Debug.Log(difficultyLevel);
    }

    public void onDeath()
    {

        isDead = true;
        //PlayerPrefs.SetFloat("HighScore", score);
        //ToggleDeathMenu(score);
        //deathMenu.gameObject.SetActive(true);
        //deathMenu.ToggleDeathMenu(score);
        //deathMenu.ToggleEndMenu(score);
    }

    //public void ToggleDeathMenu(float score)
    //{
    //    deathMenu.gameObject.SetActive(true);
    //}

    public void ScoreCompare()
    {
        //PlayerPrefs.SetInt("Score", (int)score);

        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",(int)score);
        }
        //else
        //{
        //    PlayerPrefs.SetInt("HighScore", (int)score);
        //}
    }

    public void showHighScore()
    {
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
