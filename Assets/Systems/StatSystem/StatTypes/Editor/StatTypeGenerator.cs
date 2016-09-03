using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.IO;
using System.Text;
using Systems.StatSystem;

namespace Systems.StatSystem.Editor
{
    public class StatTypeGenerator
    {
        const string defaultFileName = "StatType.cs";
        static public void CheckAndGenerateFile()
        {
            string assetPath = GetAssetPathForFile(defaultFileName);
            if (string.IsNullOrEmpty(assetPath))
            {
                string getAssetPath = GetAssetPathForFile("StatTypeGenerator.cs");
                assetPath = getAssetPath.Replace("Editor/StatTypeGenerator.cs", defaultFileName);
            }
            WriteStatTypesToFile(assetPath);
        }



        static string GetAssetPathForFile(string name)
        {
            string[] assetPaths = AssetDatabase.GetAllAssetPaths();
            foreach(var path in assetPaths)
            {
                if (path.Contains(name))
                {
                    return path;
                }
            }
            return string.Empty;
        }

        public static void WriteStatTypesToFile(string filepath)
        {
            using (StreamWriter file = File.CreateText(filepath)){
                file.WriteLine("/// <summary>");
                file.WriteLine("/// THIS IS A GENERATED FILE");
                file.WriteLine("/// ANY EDITS WILL BE DELETED ON NEXT GENERATION");
                file.WriteLine("/// Generated Enum that can be used to easily select a StatType from the StatTypeDatabase.");
                file.WriteLine("/// The value assigned to each enum key is the ID of that statType within the StatTypeDatabase");
                file.WriteLine("/// </summary>");

                file.WriteLine("namespace Systems.StatSystem");
                file.WriteLine("{");
                file.WriteLine("\tpublic enum StatType\n\t{");
                file.WriteLine("\t\tNone = 0,");

                for (int i = 0; i < StatTypeDatabase.Instance.Count; i++)
                {
                    var statType = StatTypeDatabase.GetAt(i);
                    if (!string.IsNullOrEmpty(statType.Name))
                    {
                        if(i == (StatTypeDatabase.Instance.Count - 1))
                        {
                            file.WriteLine(string.Format("\t\t{0} = {1}", statType.Name.Replace(" ", string.Empty), statType.ID));
                        }
                        else
                        {
                            file.WriteLine(string.Format("\t\t{0} = {1},", statType.Name.Replace(" ", string.Empty), statType.ID));
                        }
                        
                    }
                }

                file.WriteLine("\t}\n}");
            }
            AssetDatabase.Refresh();
        }

    }
}

