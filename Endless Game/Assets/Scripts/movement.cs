using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{

    private Rigidbody2D rbBody;
    public float silaSkoku = 500;
    public bool kierunekWPrawo = true;
    public Transform spawnPosition;
    public Transform playerTransform;


    public Transform GroundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    private bool candoublejump;
    public int coins = 0;
    public Text coinText;
    private Animator anim;
    public int jumpCount;
    private bool doubleJump;
    int tak = 0;
    SpriteRenderer sr;
    public Text score;
    public Text highScore;
    int highscore;
    int currency;
    int speed;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collectable")
        {
            Destroy(collision.gameObject);
            coins += 1;
            currency++;
            PlayerPrefs.SetInt("currency", currency);
            PlayerPrefs.Save();
            coinText.text = currency.ToString();
        }

        if (collision.tag == "Enemy")
        {
            playerTransform.position = spawnPosition.position;
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);

        }
        if (collision.tag == "SuperJump")
        {
            Destroy(collision.gameObject);
            silaSkoku = 625;
            if (tak == 1 && silaSkoku == 625)
            {
                sr.color = Color.green;
            }
            else if (silaSkoku==625)
            {
                sr.color = Color.cyan;
            }
            StartCoroutine(ResetPower1());
        }
        if (collision.tag == "SuperSpeed")
        {
            Destroy(collision.gameObject);
            if (tak == 0 && silaSkoku == 625)
            {
                sr.color = Color.green;
            }
            tak = 1;
            if (tak == 1 && silaSkoku != 625)
            {
                sr.color = Color.red;
            }
            StartCoroutine(ResetPower());
        }
        if (collision.tag == "follow")
        {
            Destroy(collision.gameObject);
            playerTransform.position = spawnPosition.position;
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }

    }

    void Flip()
    {
        kierunekWPrawo = !kierunekWPrawo; //jeśli było w prawy czyli true zmieniany na false i na odwrót
        transform.Rotate(0f, 180f, 0f);
    }

    // Use this for initialization
    void Start()
    {
        rbBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        highscore = PlayerPrefs.GetInt("highscore");
        currency = PlayerPrefs.GetInt("currency");
        speed = PlayerPrefs.GetInt("speed");
        coinText.text = currency.ToString();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (highscore <= coins)
        {
            highscore = coins;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
        }
        highScore.text = "Highscore: " + highscore;
        score.text = "Score: " + coins;
        

        if (grounded)
        {
            doubleJump = false;
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        float ruchPoziomy = Input.GetAxis("Horizontal");
        float ruchPionowy = Input.GetAxis("Vertical");

        rbBody.velocity = new Vector2(ruchPoziomy * speed, rbBody.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && grounded && coins<5)
        {
            anim.SetTrigger("takeOf");
            rbBody.AddForce(new Vector2(0f, silaSkoku));
        }


        if (Input.GetKeyDown(KeyCode.Space) && grounded  && coins >=5)
        {
            rbBody.velocity = new Vector2(rbBody.velocity.x, 0);
            rbBody.AddRelativeForce(new Vector2(0, silaSkoku));
            candoublejump = true;
            jumpCount++;
            anim.SetTrigger("takeOf");

        }
        else
        {
            if (candoublejump == true && Input.GetKeyDown(KeyCode.Space))
            {
                rbBody.velocity = new Vector2(rbBody.velocity.x, 0);
                rbBody.AddRelativeForce(new Vector2(0, silaSkoku));
                candoublejump = false;
                jumpCount = 1;

            }
        }
        



        Vector3 skala = gameObject.transform.localScale;

        if (ruchPoziomy < 0 && kierunekWPrawo == true) //Jeślizmienna ruchPoziomy jest mniejsza od zera to ruch w lewo
        {
            Flip();
        }

        if (ruchPoziomy > 0 && kierunekWPrawo == false)
        {
            Flip();
        }

        if (ruchPoziomy < 0 || ruchPoziomy > 0)
        {
            anim.SetInteger("FazaAnimacji", 1);
        }
        else
        {
            anim.SetInteger("FazaAnimacji", 0);
        }

        if (playerTransform.position.y < -30)
        {
            playerTransform.position = spawnPosition.position;
             Scene thisScene = SceneManager.GetActiveScene();
             SceneManager.LoadScene(thisScene.name);
            

        }

        if(tak==1)
        {
            rbBody.velocity = new Vector2(ruchPoziomy * speed * 2, rbBody.velocity.y);
           
        }
       

    }
    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(10);
        tak = 0;
        if (silaSkoku == 450 &&tak==0)
        {
            sr.color = Color.white;
        }
    }
    private IEnumerator ResetPower1()
    {
        yield return new WaitForSeconds(10);
        silaSkoku = 450;
        if (tak == 0)
        {
            sr.color = Color.white;
        }
    }



}