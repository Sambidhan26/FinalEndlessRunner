using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    DetectionPanel detectionPanel;
    public static PlayerController instance;
    ScoreScript scoreScript;
    private bool moveLeft, moveRight;
    private bool isDead = false;
    private Slider slider;
    [SerializeField]
    private float speed;

    public int health = 3;
    //public GameObject[] hearts;
    //public bool gameOver;

    public Rigidbody playerRB;

    public Transform playerTrans;
    public GameObject heartPanel;

    public DeathMenu deathMenu;
    public GameObject healthBar;


    private Vector3 firstPosition;
    private Vector3 lastPosition;

    Animator anim;


    private float dragDistance;      // minimum distance for swipe
    //public float x1;
    //public float x2;
    //public float move = 0;
    //public Text touchText;
    //public DeathMenu deathMenu;
    //private int score;
    //private CharacterController characterController;
    // Start is called before the first frame update

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    void Start()
    {
        //detectionPanel = GameObject.Find("Main Camera").GetComponentInChildren<DetectionPanel>();
        //health = 0;
        anim = GetComponent<Animator>();
        dragDistance = Screen.height * 15 / 100;
        slider = GameObject.Find("Canvas").GetComponentInChildren<Slider>();
        scoreScript = GetComponent<ScoreScript>();
        playerRB = GetComponent<Rigidbody>();
        playerTrans = GetComponent<Transform>();
        //audioSource = GetComponent<AudioSource>();
        //characterController = GetComponent<CharacterController>();

        //if(isDead)
        //{
        //    playerTrans.position = Vector3.zero;
        //}

        //slider.value = health;
        setSpeedDifficulty(speed);

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;


        //setSpeedDifficulty(speed);
        //TouchDetection();
        //if(!isDead)
        //{

        //}

        //if (health < 1)
        //{
        //    Destroy(hearts[0].gameObject);
        //}
        //else if (health < 2)
        //{
        //    Destroy(hearts[1].gameObject);
        //}
        //else if (health < 3)
        //{
        //    Destroy(hearts[2].gameObject);
        //}

        if (isDead)
        {
            //playerTrans.position = Vector3.zero;
            return;
        }

        if (playerTrans.position.y < -2.0f)
        {
            deathMenu.gameObject.SetActive(true);
            healthBar.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            audioSource1.Stop();
            //onDeath();
            isDead = true;
            onDeath();
        }

        //if(!isDead)
        //{
        //    heartPanel.SetActive(true);
        //}

        //deathMenu.gameObject.SetActive(true);
#if UNITY_EDITOR
        moveLeft = Input.GetKeyDown(KeyCode.A);
        moveRight = Input.GetKeyDown(KeyCode.D);
        if (moveLeft)
        {
            //transform.Translate(Vector3.left);
            playerTrans.Translate(new Vector3(-1.5f, 0, 0));
        }
        else if (moveRight)
        {
            //transform.Translate(Vector3.right);
            playerTrans.Translate(new Vector3(1.5f, 0, 0));
        }
#endif
        //TouchDetection();

        //playerRB.AddForce(Vector3.forward * speed);
        playerRB.MovePosition(transform.position +  Vector3.forward * speed * Time.deltaTime);


#if UNITY_ANDROID

        TouchDetection();
#endif
        

        //if(this.transform.position.y <= -0.1f && gameOver)
        //{
        //    scoreScript.ScoreUpdate();
        //    gameOver = false;
        //}
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("Hello World");
        //    characterController.SimpleMove(new Vector3(-3.0f, 0, 0));
        //}
        //else if(Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("Hello World2");
        //    characterController.SimpleMove(new Vector3(3.0f, 0, 0));
        //}

        //characterController.SimpleMove(new Vector3(0, 0, 0));
        //characterController.Move(transform.forward * speed * Time.deltaTime);

        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        //characterController.SimpleMove(forward * speed * Time.deltaTime);

        //if(Input.GetMouseButtonDown(0))
        //{
        //    x1 = Input.mousePosition.x;
        //}

        //if(Input.GetMouseButtonDown(0))
        //{
        //    x2 = Input.mousePosition.x;
        //}

        //if(x1 >x2)
        //{
        //    showText.text = "Left Move";
        //    //transform.Translate(new Vector3(-1.0f, 0, 0));
        //    move = 1f;
        //}

        //if(x2 > x1)
        //{
        //    showText.text = "Right Move";
        //    //transform.Translate(new Vector3(1.0f, 0, 0));
        //    move = 2f;
        //}

        //if(move == 1)
        //{
        //    Debug.Log("Hello Right");
        //    transform.Translate(new Vector3(-1.0f, 0, 0));
        //    //playerTrans.Translate(Vector2.left * (3 * Time.deltaTime));
        //}

        //if(move == 2)
        //{
        //    Debug.Log("Hello Left");
        //    transform.Translate(new Vector3(1.0f, 0, 0));
        //    //playerTrans.Translate(Vector2.right * (3 * Time.deltaTime));
        //}


    }

    public void TouchDetection()
    {

        //if (isDead)
        //{
        //    //playerTrans.position = Vector3.zero;
        //    return;
        //}

        //onDeath();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstPosition = touch.position;
                lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lastPosition = touch.position;
                if (Mathf.Abs(lastPosition.x - firstPosition.x) > dragDistance || Mathf.Abs(lastPosition.y - firstPosition.y) > dragDistance)
                {
                    if (Mathf.Abs(lastPosition.x - firstPosition.x) > Mathf.Abs(lastPosition.y - firstPosition.y))
                    {
                        if ((lastPosition.x > firstPosition.x))
                        {
                            //Right Swipe
                            //touchText.text = "Right Swipe";
                            this.transform.Translate(new Vector3(1.5f, 0, 0));

                            //if(this.transform.position.y < -2.0f)
                            //{
                            //    deathMenu.gameObject.SetActive(true);
                            //    healthBar.gameObject.SetActive(false);
                            //    this.gameObject.SetActive(false);
                            //    onDeath();
                            //    isDead = true;
                            //    onDeath();
                            //}
                        }

                        else
                        {
                            //Left Swipe
                            //touchText.text = "Left Swipe";
                            this.transform.Translate(new Vector3(-1.5f, 0, 0));

                        }
                    }
                    else
                    {
                        if (lastPosition.y > firstPosition.y)
                        {
                            //Top Swipe
                            //touchText.text = "Top Swipe";
                        }
                        else
                        {
                            //Down Swipe
                            //touchText.text = "Down Swipe";
                        }
                    }
                }
                else
                {
                    //Its a Tap
                    //touchText.text = "Just a Tap";
                }
            }

            //if (this.transform.position.y < -2.0f)
            //{
            //    deathMenu.gameObject.SetActive(true);
            //    healthBar.gameObject.SetActive(false);
            //    this.gameObject.SetActive(false);
            //    //onDeath();
            //    isDead = true;
            //    onDeath();
            //}
        }

    }


    public void setSpeedDifficulty(float changeSpeed)
    {
        speed = 5.0f + changeSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Block2")
        {

            health -= 1;
            anim.SetTrigger("SideTrigger");
            audioSource2.Play();
            //Debug.Log("HelloWorld");

        }

        if (health <= 0)
        {
            slider.gameObject.SetActive(false);
            onDeath();
            deathMenu.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            audioSource1.Stop();
            //onDeath();
        }
        //health -= 1;

        //HealthBarScript.instance.SetHealth(health);
        //deathMenu.gameObject.SetActive(true);

        //if (health < 1)
        //{
        //    Destroy(hearts[0].gameObject);
        //}
        //else if (health < 2)
        //{
        //    Destroy(hearts[1].gameObject);
        //}
        //else if (health < 3)
        //{
        //    Destroy(hearts[2].gameObject);
        //}


        //if (health <= 0)
        //{
        //    this.gameObject.SetActive(false);
        //}
        //Destroy(this.gameObject);
        //deathMenu.gameObject.SetActive(true);
        //GetComponent<DeathMenu>().ToggleDeathMenu(score);
        //this.gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hello1111");
        //health -= 1;

        //DetectionPanel.instance.healthBar -= 1;

        //DetectionPanel.instance.decementHealth(health);
        
        if (collision.collider.tag == "leftWall")
        {
            health -= 1;
            //Debug.Log("HelloLeftWall");
            playerRB.AddForce(Vector3.right * 10);
            audioSource2.Play();

            //detectionPanel.decrementHealth(health);
        }
        if (collision.collider.tag == "rightWall")
        {
            health -= 1;
            //Debug.Log("RightWall");
            playerRB.AddForce(Vector3.left * 10);
            audioSource2.Play();
            //detectionPanel.decrementHealth(health);
        }

        if(collision.collider.tag == "Block")
        {
            //Debug.Log("Hello World");
            health -= 3;
            audioSource2.Play();
        }

        if(health <= 0)
        {
            slider.gameObject.SetActive(false);
            onDeath();
            deathMenu.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            audioSource1.Stop();
            //onDeath();
        }
    }

    public void onDeath()
    {
        //if (health <= 0)
        //{
            isDead = true;
        audioSource1.Stop();
        GetComponent<ScoreScript>().onDeath();
        //}
        //deathMenu.gameObject.SetActive(true);
    }
}
