using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Systems.ItemSystem.Editor
{
    //[CustomEditor(typeof(ItemDatabase))]
    public class ItemInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("Database that stores all Item Information");

            if (GUILayout.Button("Open Editor Window"))
            {
                ItemEditor.ShowWindow();
            }
        }
    }
}