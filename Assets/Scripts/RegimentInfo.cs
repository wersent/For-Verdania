using System;
using UnityEngine;

namespace Level
{
    class RegimentInfo : ScriptableObject
    {
        [SerializeField]
        private int _health;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private DamageType _damageType; // способ нанесения урона (например, ближний бой или дальний бой)
        [SerializeField]
        private DamageElement _damageElement; // тип наносимого урона (физический, элементальный (огонь, молния и тд), хворь (урон от ядов, недугов и тд) и тд).
        [SerializeField]
        private int _defence;
        [SerializeField]
        private Field _myField;

        public int Health
        {
            get => _health;
            set => _health = value;
        } // в set: логика расчёта хп
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        } // в set: логика расчёта урона
        public int Defence
        {
            get => _defence;
            set => _defence = value;
        }
        public Field MyField
        {
            get => _myField;
            set => _myField = value;
        }
        public DamageType DamageType
        {
            get => _damageType;
            set => _damageType = value;
        }
        public DamageElement DamageElement
        {
            get => _damageElement;
            set => _damageElement = value;
        }
    }

    enum DamageType
    {
        Melee,
        Range,
        Mental
    }

    enum DamageElement
    {
        Physical,
        Elemental,
        Fire = 3, Water = 3,
        Illness,
    }
}
