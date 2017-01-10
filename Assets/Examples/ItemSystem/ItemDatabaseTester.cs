using UnityEngine;
using System.Collections;
using Systems.ItemSystem;

public class ItemDatabaseTester : MonoBehaviour {
    public int testingItemID = 1;
    Item item;
    //void Start()
    //{
    //    if (ItemDatabase.ContainsAsset(testingItemID))
    //    {
    //        item = ItemDatabase.GetItemFromAsset(ItemDatabase.GetAsset(testingItemID));
    //        Debug.Log(item.Name);
    //        Debug.Log(item.Count);
    //    }
        
    //    if (item != null)
    //    {
    //        StringItem(item);
            
    //    }
    //    else {
    //        Debug.Log(string.Format("No item with item id of {0} found", testingItemID));
    //    }
    //}

    //void StringItem(Item item)
    //{
    //    Debug.Log(string.Format("Item ID: {0}, Name: {1}, Description: {2}",
    //            item.ID, item.Name, item.GetAttribute<DescriptionAttribute>().Description));
    //}
}