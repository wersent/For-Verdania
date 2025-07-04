using System;
using UnityEngine;

namespace Level
{
    public class RegimentInfo : ScriptableObject
    {
        [SerializeField]
        private int health;
        [SerializeField]
        private int damage;

        public int Health
        {
            get => health;
            set => health = value;
        } // в set: логика расчёта хп
        public int Damage
        {
            get => damage;
            set => damage = value;
        } // в set: логика расчёта урона
    }
}
