using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
class ItemContainer : MonoBehaviour
{
    public List<ItemTrash> trashList;
    public SpriteRenderer renderer { get; set; }
    public Sprite empty;
    public Sprite full;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
}

