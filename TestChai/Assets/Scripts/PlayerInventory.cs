using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] List<ItemTrash> trashList = new List<ItemTrash>();

    public void UpdateTrashList(ItemTrash trash)
    {
        trashList.Add(trash);
    }
}

