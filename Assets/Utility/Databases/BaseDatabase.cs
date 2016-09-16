using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Systems.Utility.Database
{
    public class BaseDatabase<T> : AbstractDatabase<T> where T : BaseDatabaseAsset
    {
        protected override void OnAddObject(T t)
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }

        protected override void OnRemoveObject(T t)
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
}