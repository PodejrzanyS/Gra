using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public GameObject impactEffect;
    public Rigidbody2D rb;
    private float odliczanieczasu = 0f;
    public float czekaj = 0.5f;
    public float fallSpeed = 10.0f;
    public float czekajd = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    private void Update()
    {
        odliczanieczasu += Time.deltaTime;
        if(odliczanieczasu>=czekaj)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        }
        if (odliczanieczasu >= czekajd)
        {
            transform.forward *= 0;
        }

    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "yes")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.tag == "kulki")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        // Destroy(gameObject);
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }




    }
}
