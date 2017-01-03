using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Systems.EntitySystem;
using Systems.StatSystem;

[System.Serializable]
public class Info
{
    public Text name;
    public Text info;
    public Text stats;
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
        info.name.text = entity.Data.entityName;
        info.info.text = entity.Data.entityDescription;
        info.sprite.sprite = entity.Data.entityImage;
        getCollection();
        info.stats.text = "<b>" + entity.Data.entityClass.ToString()  + "</b>\n" + entity.Stats.ToString();
    }

    public void getCollection()
    {
        switch (entity.Data.entityClass)
        {
            case EntityClass.None:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Alchemist:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Assassin:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Barbarian:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Oracle:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Ninja:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Scout:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Sorcerer:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Warrior:
                gameObject.AddComponent<WarriorStatCollection>();
                break;
            case EntityClass.Wizard:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityClass.Warlord:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            default:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
        }
    }
}