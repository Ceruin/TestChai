using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    PlayerInventory inventory;

    private void Start()
    {
        var Player = GameObject.FindWithTag("Player");
        inventory = Player.GetComponent<PlayerInventory>();
    }

    private void OnMouseEnter()
    {
        transform.position = transform.position * Vector2.down;
        inventory.UpdateTrashList(new ItemTrash(2, "2", 2));
    }
}
