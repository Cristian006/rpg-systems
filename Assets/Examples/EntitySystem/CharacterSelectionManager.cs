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
            temp = Instantiate<GameObject>(cPanel);
            temp.AddComponent<BaseLevel>();
            temp.AddComponent<StatCollection>();
            temp.transform.SetParent(parent.transform);
            temp.GetComponent<CharacterPanel>().myEntity.data = EntityDatabase.GetDataFromAsset(EntityDatabase.Instance.GetAtIndex(i));

        }
    }
    
}