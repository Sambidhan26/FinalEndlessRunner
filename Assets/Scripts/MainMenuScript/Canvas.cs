using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{

    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
