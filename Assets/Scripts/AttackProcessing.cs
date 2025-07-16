using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    class AttackProcessing
    {
        private int _damage;
        private DamageType _damageType;
        private DamageElement _damageElement;

        public AttackProcessing(int damage, Regiment attacker, DamageType damageType, DamageElement damageElement)
        {
            _damage = damage;
            _damageType = damageType;
            _damageElement = damageElement;
        }

        public AttackProcessing(int damage, DamageElement damageElement)
        {
            _damage = damage;
            _damageElement = damageElement;
        }

        // получение урона или какой-либо другой шн€ги от дебаффов через конструктор, принимающий массив 

        public int Damage { get => _damage; }
        public DamageType DamageType { get => _damageType; }
        public DamageElement DamageElement { get => _damageElement; }
    }
}
