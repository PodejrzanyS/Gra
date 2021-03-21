using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim;
    public Transform firePoint;
    public int damage;
    public GameObject bulletPrefab;

    void Start()
    {

        anim = GetComponent<Animator>();
    }
        // Update is called once per frame
        void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("strzela");
            Shoot();
            
        }
    }


    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
}