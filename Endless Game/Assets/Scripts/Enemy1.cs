using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy1 : MonoBehaviour
{
    public ParticleSystem pyk;
    public GameObject shit;
    int damage;
    int health=100;
    int destroy = 0;
    [SerializeField]
    public GameObject bullet;
    float fireRate;
    float nextFire;
    Animator myAnimator;
    [System.Serializable]
  



    public class EnemyStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            curHealth = maxHealth;
        }

    }
    public EnemyStats stats = new EnemyStats();


    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.enabled = true;

        stats.Init();
        damage = PlayerPrefs.GetInt("damage", damage);


        fireRate = 2f; // szybkosc strzelania
        nextFire = Time.time;
    }

    void Update()
    {
        CheckIfTimeToFire();
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            health = health + 30;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "shoot")
        {
             health = health - damage;
            if (health <= 0 && destroy==0)
            {
                Instantiate(shit, transform.position, Quaternion.identity);
                Instantiate(shit, transform.position, Quaternion.identity);
                Instantiate(shit, transform.position, Quaternion.identity);
                myAnimator.SetBool("IsDead", true);
                Destroy(gameObject,0.5f);
                pyk.Play();
                destroy = 1;
            }

        }
        

    }

}
