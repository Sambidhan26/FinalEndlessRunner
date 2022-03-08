using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionPanel : MonoBehaviour
{
    //PlayerController playerController;
    //public static DetectionPanel instance; 

    public DeathMenu deathMenu;
    public Text scoreText;

    private Canvas canvas;
    //private Slider slider;

    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        //slider = GameObject.Find("Canvas").GetComponentInChildren<Slider>();
        //playerController = GetComponent<PlayerController>();
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value = health;
        //decrementHealth(healthBar);
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello");
        if(other.gameObject.tag == "Player")
        {
            health -= 3;
            //decrementHealth(healthBar);
            //decrementHealth(healthBar);
            //HealthBarScript.instance.SetHealth(health);
            if (health <= 0)
            {
                //Debug.Log("Debug Debug Health");
                deathMenu.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(false);
                //slider.gameObject.SetActive(false);
            }
        }
    }

    //public void decrementHealth(int score)
    //{
    //    score = healthBar;
    //}

    //public void OnCollisionEnter(Collision collision)
    //{

    //    health -= 1;

    //    if (collision.collider.tag == "leftWall")
    //    {
    //        Debug.Log("HelloLeftWall");
    //        //playerRB.AddForce(Vector3.right * 10);
    //        PlayerController.instance.playerRB.AddForce(Vector3.right * 100);
    //    }
    //    if (collision.collider.tag == "rightWall")
    //    {
    //        Debug.Log("RightWall");
    //        PlayerController.instance.playerRB.AddForce(Vector3.left * 100);
    //    }
    //}
}
