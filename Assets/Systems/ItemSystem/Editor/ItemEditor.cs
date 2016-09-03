using UnityEngine;
using UnityEditor;
using System.Collections;
using Systems.StatSystem;

namespace Systems.ItemSystem.Editor
{
    public partial class ItemEditor : EditorWindow
    {
        [MenuItem("Window/Systems/Item Database %#I")]
        static public void ShowWindow()
        {
            var window = GetWindow<ItemEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent.text = "Item System";
            window.Show();
        }

        private Vector2 scrollPosition;
        private int activeID;

        private GUIStyle _toggleButtonStyle;
        private GUIStyle ToggleButtonStyle
        {
            get
            {
                if (_toggleButtonStyle == null)
                {
                    _toggleButtonStyle = new GUIStyle(EditorStyles.toolbarButton);
                    ToggleButtonStyle.alignment = TextAnchor.MiddleLeft;
                }
                return _toggleButtonStyle;
            }
        }


        public void OnEnable()
        {
            tabState = TabState.ABOUT;
        }

        public void OnGUI()
        {
            EditorStyles.textField.wordWrap = true;
            TabBar();
            GUILayout.BeginHorizontal();
            switch (tabState)
            {
                case TabState.WEAPONS:

                    scrollPosition = GUILayout.BeginScrollView(scrollPosition);

                    for (int i = 0; i < WeaponDatabase.GetAssetCount(); i++)
                    {
                        WeaponAsset asset = WeaponDatabase.GetAt(i);
                        if (asset != null)
                        {
                            GUILayout.BeginHorizontal(EditorStyles.toolbar);
                            GUILayout.Label(string.Format("ID: {0}", asset.ID.ToString("D3")), GUILayout.Width(60));

                            bool clicked = GUILayout.Toggle(asset.ID == activeID, asset.Name, ToggleButtonStyle);

                            if (clicked != (asset.ID == activeID))
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
                                WeaponDatabase.Instance.RemoveAt(i);
                            }

                            GUILayout.EndHorizontal();

                            if (activeID == asset.ID)
                            {
                                EditorGUI.BeginChangeCheck();

                                GUILayout.BeginVertical("Box");

                                GUILayout.BeginHorizontal();
                                //SPRITE ON LEFT OF HORIZONTAL
                                GUILayout.BeginVertical(GUILayout.Width(75)); //begin vertical
                                GUILayout.Label("Item Sprite", GUILayout.Width(72));
                                asset.Icon = (Sprite)EditorGUILayout.ObjectField(asset.Icon, typeof(Sprite), false, GUILayout.Width(72), GUILayout.Height(72));
                                GUILayout.EndVertical();   //end vertical

                                GUILayout.BeginVertical(); //begin vertical
                                GUILayout.Label(asset.IType.ToString(), EditorStyles.boldLabel);
                                GUILayout.BeginHorizontal();
                                GUILayout.Label("Name", GUILayout.Width(80));
                                asset.Name = EditorGUILayout.TextField(asset.Name);
                                GUILayout.EndHorizontal();
                                GUILayout.BeginHorizontal();
                                GUILayout.Label("Description", GUILayout.Width(80));
                                asset.Description = EditorGUILayout.TextArea(asset.Description, GUILayout.MinHeight(30));
                                GUILayout.EndHorizontal();
                                GUILayout.BeginHorizontal();
                                GUILayout.Label("Attack Range", GUILayout.Width(80));
                                asset.AttackRange = EditorGUILayout.IntSlider(asset.AttackRange, 1, 20);
                                GUILayout.EndHorizontal();

                                GUILayout.BeginHorizontal();
                                GUILayout.Label("Weapon Damage", GUILayout.Width(80));
                                asset.WeaponDamage = EditorGUILayout.IntSlider(asset.WeaponDamage, 0, 99);
                                GUILayout.EndHorizontal();
                                GUILayout.EndVertical();

                                GUILayout.EndHorizontal();

                                GUILayout.EndVertical();
                                if (EditorGUI.EndChangeCheck())
                                {
                                    EditorUtility.SetDirty(WeaponDatabase.Instance);
                                }
                            }

                        }
                    }

                    GUILayout.EndScrollView();

                    break;
                case TabState.CONSUMABLES:
                    break;
                case TabState.QUEST_ITEMS:
                    GUILayout.Label("Quest Items");
                    break;
                default:
                    GUILayout.Label("Default State - About");
                    break;
            }

            GUILayout.EndHorizontal();
            StatusBar();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Create Weapon", EditorStyles.toolbarButton))
            {
                var newAsset = new WeaponAsset(WeaponDatabase.Instance.GetNextId());
                WeaponDatabase.Instance.Add(newAsset);
            }
            if (GUILayout.Button("Create Consumable", EditorStyles.toolbarButton))
            {
                var newAsset = new ConsumableAsset(WeaponDatabase.Instance.GetNextId());
                ConsumableDatabase.Instance.Add(newAsset);
            }
            if (GUILayout.Button("Create Quest Item", EditorStyles.toolbarButton))
            {
                var newAsset = new QuestAsset(WeaponDatabase.Instance.GetNextId());
                QuestDatabase.Instance.Add(newAsset);
            }
            GUILayout.EndHorizontal();
        }
    }
}