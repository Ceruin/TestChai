using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    // ------------------------------------------------------------------
    //                              TODO
    // Make functional, when button/key pressed add to inventory
    // ------------------------------------------------------------------

    private PlayerInventory inventory;

    private bool isInPickupRange;

    private void Start()
    {
        var Player = GameObject.FindWithTag("Player");
        inventory = Player.GetComponent<PlayerInventory>();
        isInPickupRange = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInPickupRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInPickupRange = false;
    }

    private void Update()
    {
        if (isInPickupRange)
        {
            print("Eyyo");
            inventory.UpdateTrashList(new ItemTrash(2, "2", 2));
        }
    }
}
