using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Systems.Utility.Database
{
    public class SODatabase<T> : AbstractDatabase<T> where T : SODatabaseAsset
    {
        protected override void OnAddObject(T t)
        {
#if UNITY_EDITOR
            t.hideFlags = UnityEngine.HideFlags.HideInHierarchy;
            AssetDatabase.AddObjectToAsset(t, this);
            EditorUtility.SetDirty(this);
#endif
        }

        protected override void OnRemoveObject(T t)
        {
#if UNITY_EDITOR
            DestroyImmediate(t, true);
            EditorUtility.SetDirty(this);
#endif
        }
    }
}
