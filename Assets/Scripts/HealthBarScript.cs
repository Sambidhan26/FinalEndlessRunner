using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    //PlayerController playerController;
    public static HealthBarScript instance;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //slider.value = PlayerController.instance.health;
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value = playerController.health;
    }

    //public void SetMaxHealth(float health)
    //{
    //    slider.maxValue = health;
    //    slider.value = health;
    //}

    //public void SetHealth(float health)
    //{
    //    slider.value = health;
    //}
}
