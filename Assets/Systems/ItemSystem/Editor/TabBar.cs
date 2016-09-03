using UnityEngine;
using System.Collections;

namespace Systems.ItemSystem.Editor
{
    public partial class ItemEditor
    {
        enum TabState
        {
            WEAPONS,
            CONSUMABLES,
            QUEST_ITEMS,
            ABOUT
        }

        TabState tabState;

        void TabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            WeaponTab();
            ConsumableTab();
            QuestItemTab();
            AboutTab();

            GUILayout.EndHorizontal();
        }

        void WeaponTab()
        {
            if (GUILayout.Button("Weapons"))
            {
                tabState = TabState.WEAPONS;
            }
        }

        void ConsumableTab()
        {
            if (GUILayout.Button("Consumables"))
            {
                tabState = TabState.CONSUMABLES;
            }
        }

        void QuestItemTab()
        {
            if (GUILayout.Button("Quest Items"))
            {
                tabState = TabState.QUEST_ITEMS;
            }
        }

        void AboutTab()
        {
            if (GUILayout.Button("About"))
            {
                tabState = TabState.ABOUT;
            }
        }
    }
}
