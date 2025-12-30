using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelViewModel
{
    public class RegimentScriptable : ScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private Tuple<DamageElement, DamageElement> _regimentElement;
        [SerializeField] private Tuple<DamageType, DamageType> _regimentType;
        [SerializeField] private int _mentalHealth;

        public int Health { set; get; }
        public int Damage { set; get; }
        public int MentalHealth { set; get; }
    }

    enum DamageType
    {
        Melee,
        Range,
        Hybrid
    }

    enum DamageElement
    {
        Physic,
        Fire,
        Water,
        Wind,
        Earth
    }
}
