using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Systems.EntitySystem;
using Systems.StatSystem;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject cPanel;
    public GameObject parent;

    void Start()
    {
        Init();
    }

    void Init()
    {
        GameObject temp;
        for(int i = 0; i < EntityDatabase.Instance.Count; i++)
        {
            temp = Instantiate(cPanel);
            temp.transform.SetParent(parent.transform);
            temp.GetComponent<CharacterPanel>().myEntity.Data = EntityDatabase.GetDataFromAsset(EntityDatabase.Instance.GetAtIndex(i));
        }
    }
}