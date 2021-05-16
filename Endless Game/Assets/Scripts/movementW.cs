using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movementW : MonoBehaviour
{

    private Rigidbody2D rbBody;
    public float silaSkoku = 500;
    public bool kierunekWPrawo = true;
    public Transform spawnPosition;
    public Transform playerTransform;
    int number;
    System.Random random = new System.Random();

    public Transform GroundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    private bool candoublejump;
    public int coins = 0;
    private Animator anim;
    public int jumpCount;

    int tak = 0;
    SpriteRenderer sr;
    public Text score;
    public Text highScore;
    public Text level;
    int highscore;
    int currency;
    int speed;
    int health;
    float curHealth;
    int maxHealth;
    int zabici;
    int lvl;
    int exp;
    int n;
    int m = 200;
    public Text zabity;
    int destroy = 0;
    public HealthBar healthBar;

    public void Level()
    {
        if (exp > m)
        {
            lvl++;
            m = m * lvl;
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
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
    }


    // Update is called once per frame
    void Update()
    {

        if (grounded)
        {

            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        float ruchPoziomy = Input.GetAxis("Horizontal");
        float ruchPionowy = Input.GetAxis("Vertical");

        rbBody.velocity = new Vector2(ruchPoziomy * speed, rbBody.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && grounded && coins < 5)
        {
            anim.SetTrigger("takeOf");
            rbBody.AddForce(new Vector2(0f, silaSkoku));
        }


        if (Input.GetKeyDown(KeyCode.Space) && grounded && coins >= 5)
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

        PlayerPrefs.SetInt("coins", coins);

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

        if (tak == 1)
        {
            rbBody.velocity = new Vector2(ruchPoziomy * speed * 2, rbBody.velocity.y);

        }

    }


}