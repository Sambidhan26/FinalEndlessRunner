using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{

    public Text endScoreText;

    //public GameObject mainMenu;
    //public DeathMenu deathMenu;
    // Start is called before the first frame update

    //private bool isDead = false;
    void Start()
    {
        //if (isDead)
        
            //gameObject.SetActive(false);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.SetActive(true);
    }

    public void ToggleEndMenu(float score)
    {
        //Debug.Log("Hello123");
        gameObject.SetActive(true);
        endScoreText.text = ((int)score).ToString();
    }

    public void Restart()
    {
        //mainMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuPage()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
 