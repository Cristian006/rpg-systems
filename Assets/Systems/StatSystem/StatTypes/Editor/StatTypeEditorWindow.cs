using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Systems.StatSystem.Editor
{
    public class StatTypeEditorWindow : EditorWindow
    {        
        [MenuItem("Window/Systems/Stat Types %#T")]
        static public void ShowWindow()
        {
            var window = GetWindow<StatTypeEditorWindow>();
            window.titleContent.text = "Stat Types";
            window.Show();
        }

        private Vector2 scrollPosition;
        private int activeID;

        private GUIStyle _toggleButtonStyle;
        private GUIStyle ToggleButtonStyle
        {
            get
            {
                if(_toggleButtonStyle == null)
                {
                    _toggleButtonStyle = new GUIStyle(EditorStyles.toolbarButton);
                    ToggleButtonStyle.alignment = TextAnchor.MiddleLeft;
                }
                return _toggleButtonStyle;
            }
        }

        public void OnEnable()
        {

        }

        public void OnGUI()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            for(int i =0; i < StatTypeDatabase.GetAssetCount(); i++)
            {
                var asset = StatTypeDatabase.GetAt(i);
                if(asset != null)
                {
                    GUILayout.BeginHorizontal(EditorStyles.toolbar);
                    GUILayout.Label(string.Format("ID: {0}", asset.ID.ToString("D3")), GUILayout.Width(60));

                    bool clicked = GUILayout.Toggle(asset.ID == activeID, asset.Name, ToggleButtonStyle);

                    if(clicked != (asset.ID == activeID))
                    {
                        if (clicked)
                        {
                            activeID = asset.ID;
                            GUI.FocusControl(null);
                        }
                        else
                        {
                            activeID = -1;
                        }
                    }

                    if (GUILayout.Button("-", EditorStyles.toolbarButton, GUILayout.Width(30)) && EditorUtility.DisplayDialog("Delete Stat Type", "Are you sure you want to delete " + asset.Name + " Stat Type?", "Delete", "Cancel"))
                    {
                        StatTypeDatabase.Instance.RemoveAt(i);
                    }

                    GUILayout.EndHorizontal();

                    if(activeID == asset.ID)
                    {
                        EditorGUI.BeginChangeCheck();

                        //START OF SELECTED VIEW
                        GUILayout.BeginVertical("Box");
                        GUILayout.BeginHorizontal();
                        //SPRITE ON LEFT OF HORIZONTAL
                        GUILayout.BeginVertical(GUILayout.Width(75)); //begin vertical
                        GUILayout.Label("Stat Sprite", GUILayout.Width(72));
                        asset.Icon = (Sprite)EditorGUILayout.ObjectField(asset.Icon, typeof(Sprite), false, GUILayout.Width(72), GUILayout.Height(72));
                        GUILayout.EndVertical();   //end vertical
                        
                        //INFO ON RIGHT OF HORIZONTAL
                        GUILayout.BeginVertical(); //begin vertical

                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Name", GUILayout.Width(80));
                        asset.Name = EditorGUILayout.TextField(asset.Name);
                        GUILayout.EndHorizontal();
                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Short Name", GUILayout.Width(80));
                        asset.ShortName = EditorGUILayout.TextField(asset.ShortName);
                        GUILayout.EndHorizontal();
                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Description", GUILayout.Width(80));
                        asset.Description = EditorGUILayout.TextArea(asset.Description, GUILayout.MinHeight(50));
                        GUILayout.EndHorizontal();

                        GUILayout.EndVertical();  //end vertical

                        GUILayout.EndHorizontal();
                        GUILayout.EndVertical();

                        if (EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(StatTypeDatabase.Instance);
                        }
                    }

                }
            }

            GUILayout.EndScrollView();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add Type", EditorStyles.toolbarButton))
            {
                var newAsset = new StatTypeAsset(StatTypeDatabase.Instance.GetNextId());
                StatTypeDatabase.Instance.Add(newAsset);
            }

            if(GUILayout.Button("Generate StatType Enum", EditorStyles.toolbarButton))
            {
                StatTypeGenerator.CheckAndGenerateFile();
            }

            GUILayout.EndHorizontal();
        }
    }
}

