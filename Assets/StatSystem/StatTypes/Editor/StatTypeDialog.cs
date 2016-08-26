using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Systems.StatSystem.Editor
{
    public class StatTypeDialog : EditorWindow
    {
        const string windowTitle = "Stat Types";

        public delegate void SelectEvent(StatTypeAsset asset);

        public SelectEvent OnAssetSelect;

        private Vector2 scroll;

        static public void Display(SelectEvent del)
        {
            var window = GetWindow<StatTypeDialog>(true, windowTitle, true);
            window.OnAssetSelect = del;
            window.Show();
        }

        public void OnGUI()
        {
            scroll = GUILayout.BeginScrollView(scroll);
            for(int i = 0; i < StatTypeDatabase.GetAssetCount(); i++)
            {
                var asset = StatTypeDatabase.GetAt(i);
                if(asset != null)
                {
                    if (GUILayout.Button(asset.Name, EditorStyles.toolbarButton))
                    {
                        if(OnAssetSelect != null)
                        {
                            OnAssetSelect(asset);
                        }
                        this.Close();
                    }
                }
            }

            GUILayout.EndScrollView();
        }
    }
}
