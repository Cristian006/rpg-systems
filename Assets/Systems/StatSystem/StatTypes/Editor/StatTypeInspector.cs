using UnityEngine;
using UnityEditor;
using Systems.StatSystem;
using System.Collections;

namespace Systems.StatSystem.Editor
{
    [CustomEditor(typeof(StatTypeDatabase))]
    public class StatTypeInspector : UnityEditor.Editor
    {
        //private string output = "";
        public override void OnInspectorGUI()
        {
            GUILayout.Label("Database that stores all StatTypes");

            if (GUILayout.Button("Open Editor Window"))
            {
                StatTypeEditorWindow.ShowWindow();
            }

            /*//TEST CODE
            if (GUILayout.Button("Stat Type Dialog Test"))
            {
                StatTypeDialog.Display((asset) =>
                {
                    output = asset.Name;
                });
            }

            if(output != "")
            {
                EditorGUILayout.HelpBox(output, MessageType.None);
            }
            */
        }
    }
}