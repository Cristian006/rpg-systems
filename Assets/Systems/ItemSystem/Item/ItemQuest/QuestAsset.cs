using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.ItemSystem
{
    [System.Serializable]
    public class QuestAsset : ItemAsset
    {
        public QuestAsset() : base()
        {
            IType = ItemType.Quest;
        }

        public QuestAsset(int id) : base(id)
        {
            IType = ItemType.Quest;
        }

        public QuestAsset(int id, string name) : base (id, name)
        {
            IType = ItemType.Quest;
        }
    }
}
