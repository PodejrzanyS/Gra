using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeMenu;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player shopCustomer = collider.GetComponent<Player>();
        if (shopCustomer != null)
        {
            UpgradeMenu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Player shopCustomer = collider.GetComponent<Player>();
        if (shopCustomer != null)
        {
            UpgradeMenu.SetActive(false);
        }
    }
}
