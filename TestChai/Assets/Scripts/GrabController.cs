using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrabController : MonoBehaviour
{
    // ------------------------------------------------------------------
    //                              TODO
    // Make functional, when button/key pressed add to inventory
    // ------------------------------------------------------------------

    private PlayerInventory inventory;

    private bool isInPickupRange;
    private GameObject gameObject;

    private void Start()
    {
        var Player = GameObject.FindWithTag("Player");
        inventory = Player.GetComponent<PlayerInventory>();
        isInPickupRange = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInPickupRange = true;
        gameObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInPickupRange = false;
        gameObject = null;
    }

    private void Update()
    {
        if (isInPickupRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ItemContainerController container = gameObject.GetComponent<ItemContainerController>();

                switch (gameObject.tag)
                {
                    case "WasteBin":
                        ItemTrash inventoryTrash = inventory.GetTrashItem();
                        if (inventoryTrash.item != null)
                        {
                            container.AddItem(inventoryTrash);
                            inventory.RemoveTrashItem(inventoryTrash);
                        }
                        break;
                    case "TrashCan":
                        ItemTrash containerTrash = container.GetTrashItem();
                        if (containerTrash.item != null)
                        {
                            inventory.AddTrashItem(containerTrash);
                            container.RemoveItem(containerTrash);
                        }
                        break;
                }
            }          
        }
    }
}
