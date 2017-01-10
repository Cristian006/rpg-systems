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
            case EntityType.None:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Alchemist:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Assassin:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Barbarian:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Oracle:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Ninja:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Scout:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Sorcerer:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Warrior:
                gameObject.AddComponent<WarriorStatCollection>();
                break;
            case EntityType.Wizard:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            case EntityType.Warlord:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
            default:
                gameObject.AddComponent<ExampleStatCollection>();
                break;
        }
    }
}