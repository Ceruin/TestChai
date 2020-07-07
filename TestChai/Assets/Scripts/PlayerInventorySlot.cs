using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
class PlayerInventorySlot : MonoBehaviour
{
    public bool isFull { get { return item == null ? false : true; } set { isFull = value; } }
    public GameObject slot;
    public ItemTrash item;
}

