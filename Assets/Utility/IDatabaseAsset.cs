using UnityEngine;
using System.Collections;

namespace Systems.Utility.Database
{
    public interface IDatabaseAsset
    {
        int ID { get; set; }
        string Name { get; set; }
    }
}