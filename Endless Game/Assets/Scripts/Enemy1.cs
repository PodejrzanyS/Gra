using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy1 : MonoBehaviour
{
    public ParticleSystem pyk;
    public GameObject shit;
    int damage;
    [SerializeField]
    public GameObject bullet;
    float fireRate;
    float nextFire;
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
        stats.Init();
        damage = PlayerPrefs.GetInt("damage", damage);


        fireRate = 1f;
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "shoot")
        {
            stats.curHealth = stats.curHealth - damage;
            if (stats.curHealth <= 0)
            {
                Instantiate(shit, transform.position, Quaternion.identity);
                Instantiate(shit, transform.position, Quaternion.identity);
                Instantiate(shit, transform.position, Quaternion.identity);
                Destroy(gameObject);
                pyk.Play();
            }

        }
        

    }

}
