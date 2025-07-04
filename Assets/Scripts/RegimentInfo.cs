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
        } // � set: ������ ������� ��
        public int Damage
        {
            get => damage;
            set => damage = value;
        } // � set: ������ ������� �����
    }
}
