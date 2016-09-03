using UnityEngine;
using System.Collections;

namespace Systems.ItemSystem.Interfaces
{
    public interface IDestructible
    {
        /// <summary>
        /// The Items max durability
        /// </summary>
        int Durability { get; set; }

        /// <summary>
        /// The Items current Durability
        /// </summary>
        int CurrentDurability { get; set; }

        /// <summary>
        /// Damage the Item by the amount passed in
        /// </summary>
        /// <param name="amount"></param>
        void TakeDamage(int amount);

        /// <summary>
        /// Break the Item when it's current durability reaches 0
        /// </summary>
        void Break();

        /// <summary>
        /// Repair the item when it goes below it's max durability
        /// </summary>
        void Repair();
    }

}
