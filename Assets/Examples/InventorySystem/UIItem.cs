using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Systems.ItemSystem;
using Systems.InventorySystem;

public class UIItem : MonoBehaviour
{
    private Item _myItem;
    private InventoryTest iT;

    public bool EquippedItem;

    public bool equipped = false;

    public Image i;
    public Text n;
    public Text desc;
    public Image background;
    public Text equipText;

    public Color defaultColor;

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

    void OnEnable()
    {
        LoadItem();
    }

    void OnDisable()
    {
        background.color = defaultColor;
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
        defaultColor = background.color;
        if(MyItem != null)
        {
            i.sprite = MyItem.Icon;
            n.text = string.Format("{0} Lv. {1}", MyItem.Name, MyItem.Level);
            if (!EquippedItem)
            {
                desc.text = string.Format("Cost: ${0}\nDescription: {1}", MyItem.Cost, MyItem.Description);
                if (IT.IM.isEquipped(MyItem))
                {
                    equipText.text = IT.IM.isEquipped(MyItem) ? "Un Equip" : "Equip";
                    background.color = Color.green;
                }
                else
                {
                    background.color = defaultColor;
                }
            }
        }
        else
        {
            n.text = "NO ITEM";
            i.sprite = null;
            if (!EquippedItem)
            {
                desc.text = "";
            }
        }
    }

    public void RemoveItemFromInventory()
    {
        IT.IM.Remove(MyItem);
        this.gameObject.SetActive(false);
    }

    public void EquipItem()
    {
        if (IT.IM.isEquipped(MyItem))
        {
            Debug.Log("Item is already equipped - un equipping");
            IT.IM.Equip(MyItem, false);
        }
        else
        {
            Debug.Log("Equipping Item");
            IT.IM.Equip(MyItem);
        }
        IT.updateEquipped = true;
    }
}
