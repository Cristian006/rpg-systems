using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Systems.ItemSystem;
using Systems.InventorySystem;

public class InventoryTest : MonoBehaviour {

    [SerializeField]
    private Entity sceneEntity;
    private InventoryManager im;
    public Text InventoryInfoText;
    public Text InventoryText;

    public Button[] buttons;
    public enum Selected
    {
        weapons,
        consumables,
        quest
    }

    public Selected selected = new Selected();

    public Entity SceneEntity
    {
        get
        {
            if(sceneEntity == null)
            {
                sceneEntity = GameObject.FindObjectOfType<Entity>();
                im = sceneEntity.GetComponent<InventoryManager>();
            }
            return sceneEntity;
        }
    } 

    public InventoryManager IM
    {
        get
        {
            if(SceneEntity != null)
            {
                im = SceneEntity.GetComponent<InventoryManager>();
            }
            return im;
        }
    }

	// Use this for initialization
	void Start () {
        selected = Selected.weapons;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        UpdateInventoryText();
        UpdateInventory();
	}

    public void SelectItem(int item)
    {
        selected = (Selected)item;
    }

    public void AddItem(int itemType)
    {
        ItemType i = (ItemType)itemType;
        switch (i)
        {
            case ItemType.Weapon:
                if (WeaponDatabase.Instance.Count > 0)
                {
                    int rand = Mathf.FloorToInt(Random.Range(0, (WeaponDatabase.Instance.Count))-1);
                    IM.Add<Weapon>(WeaponDatabase.GetItemFromAsset(WeaponDatabase.Instance.GetAtIndex(0)));
                }
                break;
            case ItemType.Consumable:
                if (ConsumableDatabase.Instance.Count > 0)
                {
                    int rand = Mathf.FloorToInt(Random.Range(0, (QuestDatabase.Instance.Count))-1);
                    IM.Add<Consumable>(ConsumableDatabase.GetItemFromAsset(ConsumableDatabase.Instance.GetAtIndex(0)));
                }
                break;
            case ItemType.Quest:
                if(QuestDatabase.Instance.Count > 0)
                {
                    int rand = Mathf.FloorToInt(Random.Range(0, (QuestDatabase.Instance.Count))-1);
                    IM.Add<QuestItem>(QuestDatabase.GetItemFromAsset(QuestDatabase.Instance.GetAtIndex(0)));
                }
                break;
        }
    }

    public void UpdateInventoryText()
    {
        InventoryInfoText.text = "Weight: " + IM.Weight + " / " + IM.MaxWeight + "\nWeapons: " + IM.Weapons.Count + "\nConsumables: " + IM.Consumables.Count + "\nQuestItems: " + IM.QuestItems.Count;
    }

    public void UpdateInventory()
    {
        switch (selected)
        {
            case Selected.weapons:
                InventoryText.text = "<b>Weapons</b>\n--------------------------------\n";
                foreach(var i in IM.Inventory<Weapon>().Objects)
                {
                    InventoryText.text += "Name: " + i.Name + "\nWeight: " + i.Weight + "\n--------------------------------\n";
                }

                break;
            case Selected.consumables:

                InventoryText.text = "<b>Consumables</b>\n--------------------------------\n";
                foreach (var i in IM.Inventory<Consumable>().Objects)
                {
                    InventoryText.text += "Name: " + i.Name + "\nWeight: " + i.Weight + "\n--------------------------------\n";
                }

                break;
            case Selected.quest:

                InventoryText.text = "<b>Quest Items</b>\n--------------------------------\n";
                foreach (var i in IM.Inventory<QuestItem>().Objects)
                {
                    InventoryText.text += "Name: " + i.Name + "\nWeight: " + i.Weight + "\n--------------------------------\n";
                }

                break;
            default:
                InventoryText.text = "Select an item type from the buttons above";
                break;
        }
    }
}