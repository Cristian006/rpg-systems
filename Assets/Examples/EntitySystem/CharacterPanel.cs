using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Systems.EntitySystem;

[System.Serializable]
public class Info
{
    public Text name;
    public Text info;
    public Image sprite;
}

public class CharacterPanel : MonoBehaviour
{
    public Info info;
    bool init = false;
    public Entity entity;

    public Entity myEntity{
        get
        {
            if(entity == null)
            {
                entity = GetComponent<Entity>();
            }
            return entity;
        }
        set
        {
            entity = value;
            if(entity != null)
            {
                Initialize();
            }
            else
            {
                Debug.Log(value);
            }
        }
    }

    void FixedUpdate()
    {
        if(entity != null)
        {
            if(!init)
            {
                Initialize();
                init = true;
            }
        }
    }

    public void Initialize()
    {
        info.name.text = entity.data.entityName;

        //info.info.text = entity.level.ToString();
        info.sprite.sprite = entity.data.entityImage;
    }
}