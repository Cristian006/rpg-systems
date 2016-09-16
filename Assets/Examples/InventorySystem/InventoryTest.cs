using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Systems.ItemSystem;
using Systems.InventorySystem;
using System;

public class InventoryTest : MonoBehaviour
{
    [SerializeField]
    private Entity sceneEntity;
    private InventoryManager im;
    public Text InventoryInfoText;
    public static InventoryTest instance = null;
    public Button uiItemPrefab;
    public GameObject scrollViewContent;
    public List<Button> buttons = new List<Button>();

    public EventHandler OnTabChange;

    public ItemType selected = new ItemType();

    public Button[] equipped = new Button[3];

    public Entity SceneEntity
    {
        get
        {
            if (sceneEntity == null)
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
            if (SceneEntity != null)
            {
                im = SceneEntity.GetComponent<InventoryManager>();
            }
            return im;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        OnTabChange += UpdateInventory;

        SelectItem(1);

        IM.OnInventoryChange += UpdateInventory;
        IM.OnPrimaryChange += UpdatePrimary;
        IM.OnSecondaryChange += UpdateSecondary;
        IM.OnTertiaryChange += UpdateTertiary;
    }

    void UpdatePrimary(object sender, System.EventArgs e)
    {
        equipped[0].GetComponent<UIItem>().MyItem = IM.Primary;
    }

    void UpdateSecondary(object sender, System.EventArgs e)
    {
        equipped[1].GetComponent<UIItem>().MyItem = IM.Secondary;
    }

    void UpdateTertiary(object sender, System.EventArgs e)
    {
        equipped[2].GetComponent<UIItem>().MyItem = IM.Tertiary;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateInventoryText();
    }

    public void SelectItem(int item)
    {
        selected = (ItemType)item;
        TriggerOnTabChange();
    }

    public void AddItem(int itemType)
    {
        ItemType i = (ItemType)itemType;
        switch (i)
        {
            case ItemType.Weapon:
                if (WeaponDatabase.Instance.Count >= 0)
                {
                    int rand = Mathf.FloorToInt(UnityEngine.Random.Range(0, (WeaponDatabase.Instance.Count)));
                    IM.Add<Weapon>(WeaponDatabase.GetItemFromAsset(WeaponDatabase.Instance.GetAtIndex(rand)));
                }
                break;
            case ItemType.Consumable:
                if (ConsumableDatabase.Instance.Count >= 0)
                {
                    int rand = Mathf.FloorToInt(UnityEngine.Random.Range(0, (QuestDatabase.Instance.Count)));
                    IM.Add<Consumable>(ConsumableDatabase.GetItemFromAsset(ConsumableDatabase.Instance.GetAtIndex(rand)));
                }
                break;
            case ItemType.Quest:
                if (QuestDatabase.Instance.Count >= 0)
                {
                    int rand = Mathf.FloorToInt(UnityEngine.Random.Range(0, (QuestDatabase.Instance.Count - 1)));
                    IM.Add<QuestItem>(QuestDatabase.GetItemFromAsset(QuestDatabase.Instance.GetAtIndex(rand)));
                }
                break;
        }
    }


    public void RemoveItem(int itemType)
    {

        ItemType i = (ItemType)itemType;
        switch (i)
        {
            case ItemType.Weapon:
                if (IM.Count<Weapon>() > 0)
                {
                    int rand = Mathf.FloorToInt(UnityEngine.Random.Range(0, (IM.Count<Weapon>() - 1)));
                    IM.RemoveAt<Weapon>(rand);
                }
                break;
            case ItemType.Consumable:
                if (IM.Count<Consumable>() > 0)
                {
                    int rand = Mathf.FloorToInt(UnityEngine.Random.Range(0, (IM.Count<Consumable>() - 1)));
                    IM.RemoveAt<Consumable>(rand);
                }
                break;
            case ItemType.Quest:
                if (IM.Count<QuestItem>() > 0)
                {
                    int rand = Mathf.FloorToInt(UnityEngine.Random.Range(0, (IM.Count<QuestItem>() - 1)));
                    IM.RemoveAt<QuestItem>(rand);
                }
                break;
        }
    }

    public void UpdateInventoryText()
    {
        InventoryInfoText.text = "Weight: " + IM.CurrentWeight + " / " + IM.MaxWeight + "\nWeapons: " + IM.Count<Weapon>() + "\nConsumables: " + IM.Count<Consumable>() + "\nQuestItems: " + IM.Count<QuestItem>();
    }

    public void UpdateInventory(object sender = null, EventArgs e = null)
    {
        switch (selected)
        {
            case ItemType.Weapon:
                int diff = buttons.Count - IM.Count<Weapon>();
                if (diff == 0)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].gameObject.SetActive(true);
                        buttons[i].GetComponent<UIItem>().MyItem = IM.Weapons.Objects[i];
                    }
                }
                else if (diff > 0)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (i < diff)
                        {
                            buttons[i].gameObject.SetActive(false);
                        }
                        else
                        {
                            buttons[i].gameObject.SetActive(true);
                            buttons[i].GetComponent<UIItem>().MyItem = IM.Weapons.Objects[i - diff];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < (buttons.Count + Mathf.Abs(diff)); i++)
                    {
                        if (i < buttons.Count)
                        {
                            buttons[i].gameObject.SetActive(true);
                            buttons[i].GetComponent<UIItem>().MyItem = IM.Weapons.Objects[i];
                        }
                        else
                        {
                            if (i < IM.Count<Weapon>())
                            {
                                Button b = Instantiate(uiItemPrefab);
                                buttons.Add(b);
                                b.gameObject.SetActive(false);
                                b.GetComponent<RectTransform>().SetParent(scrollViewContent.transform);
                                b.transform.localScale = Vector3.one;
                                b.gameObject.SetActive(true);
                                b.GetComponent<UIItem>().MyItem = IM.Weapons.Objects[i];
                            }
                        }
                    }
                }
                break;
            case ItemType.Consumable:
                diff = buttons.Count - IM.Count<Consumable>();
                if (diff == 0)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].gameObject.SetActive(true);
                        buttons[i].GetComponent<UIItem>().MyItem = IM.Consumables.Objects[i];
                    }
                }
                else if (diff > 0)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (i < diff)
                        {
                            buttons[i].gameObject.SetActive(false);
                        }
                        else
                        {
                            buttons[i].gameObject.SetActive(true);
                            buttons[i].GetComponent<UIItem>().MyItem = IM.Consumables.Objects[i - diff];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < (buttons.Count + Mathf.Abs(diff)); i++)
                    {
                        if (i < buttons.Count)
                        {
                            buttons[i].gameObject.SetActive(true);
                            buttons[i].GetComponent<UIItem>().MyItem = IM.Consumables.Objects[i];
                        }
                        else
                        {
                            if (i < IM.Count<Consumable>())
                            {
                                Button b = Instantiate(uiItemPrefab);
                                buttons.Add(b);
                                b.gameObject.SetActive(false);
                                b.GetComponent<RectTransform>().SetParent(scrollViewContent.transform);
                                b.transform.localScale = Vector3.one;
                                b.gameObject.SetActive(true);
                                b.GetComponent<UIItem>().MyItem = IM.Consumables.Objects[i];
                            }
                        }
                    }
                }
                break;
            case ItemType.Quest:
                diff = buttons.Count - IM.Count<QuestItem>();
                if (diff == 0)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].gameObject.SetActive(true);
                        buttons[i].GetComponent<UIItem>().MyItem = IM.QuestItems.Objects[i];
                    }
                }
                else if (diff > 0)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (i < diff)
                        {
                            buttons[i].gameObject.SetActive(false);
                        }
                        else
                        {
                            buttons[i].gameObject.SetActive(true);
                            buttons[i].GetComponent<UIItem>().MyItem = IM.QuestItems.Objects[i - diff];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < (buttons.Count + Mathf.Abs(diff)); i++)
                    {
                        if (i < buttons.Count)
                        {
                            buttons[i].gameObject.SetActive(true);
                            buttons[i].GetComponent<UIItem>().MyItem = IM.QuestItems.Objects[i];
                        }
                        else
                        {
                            if (i < IM.Count<QuestItem>())
                            {
                                Button b = Instantiate(uiItemPrefab);
                                buttons.Add(b);
                                b.gameObject.SetActive(false);
                                b.GetComponent<RectTransform>().SetParent(scrollViewContent.transform);
                                b.transform.localScale = Vector3.one;
                                b.gameObject.SetActive(true);
                                b.GetComponent<UIItem>().MyItem = IM.QuestItems.Objects[i];
                            }
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    public void TriggerOnTabChange()
    {
        if (OnTabChange != null)
        {
            OnTabChange(this, null);
        }
    }
}