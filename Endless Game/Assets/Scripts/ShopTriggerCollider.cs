using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeMenu;
    [SerializeField] private bool triggerActive = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
           
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E) && (!UpgradeMenu.activeSelf))
        {
            UpgradeMenu.SetActive(true);
        }
        if (!triggerActive)
        {
            UpgradeMenu.SetActive(false);
        }
        if (triggerActive)
        {
            UpgradeMenu.SetActive(false);
        }
    }
}
