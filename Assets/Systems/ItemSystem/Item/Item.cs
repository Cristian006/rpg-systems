using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Systems.StatSystem;
using System;

namespace Systems.ItemSystem
{
    public class Item
    {
        private int _id;
        private ItemType _type;
        private string _name;
        private string _description;
        private int _weight;
        private bool _stackable;

        #region GETTERS AND SETTERS
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Stackable
        {
            get { return _stackable; }
            set { _stackable = value; }
        }

        public ItemType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public int Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
            }
        }
        #endregion

        #region CONSTRUCTORS
        public Item()
        {

        }

        public Item(Item item)
        {
            ID = item.ID;
            Name = item.Name;
            Type = item.Type;
            Weight = item.Weight;
            Description = item.Description;
        }
        #endregion
    }
}