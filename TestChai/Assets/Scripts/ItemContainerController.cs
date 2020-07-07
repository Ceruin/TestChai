using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemContainerController : MonoBehaviour
{
    [SerializeField] ItemContainer container;
    [SerializeField] List<ItemTrash> tempItems = new List<ItemTrash>();

    void Start()
    {
        container = GetComponent<ItemContainer>();
        container.trashList = tempItems;
    }

    // Update is called once per frame
    void Update()
    {
        SetContainerImage();
    }

    private void SetContainerImage()
    {
        if (container.trashList.Count <= 0)
        {
            container.renderer.sprite = container.empty;
        }
        else
        {
            container.renderer.sprite = container.full;
        }
    }

    public void AddItem(ItemTrash trash)
    {
        if (trash != null)
            container.trashList.Add(trash);
    }

    public void RemoveItem(ItemTrash trash)
    {
        if (trash != null)
            container.trashList.Remove(trash);
    }

    public ItemTrash GetTrashItem()
    {
        return container.trashList.FirstOrDefault();
    }
}
