using UnityEngine;
using System.Collections;
namespace Systems.StatSystem
{
    public interface IStatLinkable
    {
        int LinkerValue { get; }

        void AddLinker(StatLinker linker);
        void ClearLinkers();
        void UpdateLinkers();
    }
}
