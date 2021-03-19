using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeMenu;


// Start is called before the first frame update
void Start()
{
   
}

// Update is called once per frame
void Update()
{
    // this is where I'm having problems
    void OnTriggerEnter2D(Collider NPC)
    {
        if (NPC.gameObject.tag == "Player")
            if (Input.GetKey("E"))
            {
              UpgradeMenu.SetActive(true);
              }

    }
}  
}