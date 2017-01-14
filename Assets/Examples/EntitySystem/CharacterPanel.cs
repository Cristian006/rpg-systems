using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Systems.EntitySystem;

namespace Systems.Example
{

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

        public Entity myEntity
        {
            get
            {
                if (entity == null)
                {
                    entity = GetComponent<Entity>();
                }
                return entity;
            }
            set
            {
                entity = value;
                if (entity != null)
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
            if (entity != null)
            {
                if (!init)
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
            info.stats.text = "<b>" + entity.Data.entityType.ToString() + "</b>\n" + entity.Stats.ToString();
        }

        public void getCollection()
        {
            switch (entity.Data.entityType)
            {
                case EntityType.None:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Alchemist:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Assassin:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Barbarian:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Oracle:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Ninja:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Scout:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Sorcerer:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Warrior:
                    gameObject.AddComponent<WarriorStatCollection>();
                    break;
                case EntityType.Wizard:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                case EntityType.Warlord:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
                default:
                    gameObject.AddComponent<AssassinStatCollection>();
                    break;
            }
        }
    }
}