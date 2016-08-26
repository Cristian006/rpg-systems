using UnityEngine;
using System.Collections;

public class ItemDatabaseTester : MonoBehaviour {
    public int testingItemID = 1;
    void Start()
    {     
        Item item = ItemDatabase.GetItem(testingItemID);

        if (item != null)
        {
            Debug.Log(string.Format("Item ID: {0}, Name: {1}, Description: {2}",
                item.itemID, item.itemName, item.itemDescription));
        }
        else {
            Debug.Log(string.Format("No item with item id of {0} found", testingItemID));
        }
    }
}
