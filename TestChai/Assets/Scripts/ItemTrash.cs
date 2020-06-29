using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class ItemTrash : iItem
{
    public int itemID { get; set; }
    public string itemName { get; set; }
    public int size { get; set; }

    public ItemTrash(int iid, string iname, int isize)
    {
        itemID = iid;
        itemName = iname;
        size = isize;
    }
}

