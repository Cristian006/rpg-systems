using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Systems.ItemSystem;
using Systems.InventorySystem;

public class UIItem : MonoBehaviour
{
    private Item _myItem;
    private InventoryTest iT;

    public Text n;
    public Text desc;

    public InventoryTest IT
    {
        get
        {
            if(iT == null)
            {
                iT = InventoryTest.instance;
            }
            return iT;
        }
    }

    public Item MyItem
    {
        get { return _myItem; }
        set
        {
            _myItem = value;
            LoadItem();
        }
    }
	
    void LoadItem()
    {
        n.text = string.Format("{0} Lv. {1}", MyItem.Name, MyItem.Level);
        desc.text = string.Format("Cost: ${0}\nDescription: {1}", MyItem.Cost, MyItem.Description);
    }

    public void RemoveItemFromInventory()
    {
        IT.IM.Remove(MyItem);
    }
}
