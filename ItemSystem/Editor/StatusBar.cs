using UnityEngine;

namespace Systems.ItemSystem.Editor
{
    public partial class ItemEditor
    {
        void StatusBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            GUILayout.Label("Status Bar");

            GUILayout.EndHorizontal();
        }
    }
}
