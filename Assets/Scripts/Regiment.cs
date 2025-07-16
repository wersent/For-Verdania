using System;
using UnityEngine;

namespace Level
{
    class Regiment
    {
        [SerializeField]
        private RegimentState _unitState;
        public event Action<RegimentState> OnStateChanged;
        public event Action<AttackProcessing> OnAttack;
        private RegimentInfo _info;
        private RegimentAI _ai;
        private RegimentView _view;

        public void GetAttacked(AttackProcessing attackStats)
        {
            _info.Health -= attackStats.Damage;
        }

        public void Attack()
        {
            OnStateChanged?.Invoke(_unitState = RegimentState.Attacking);
            OnAttack?.Invoke(new AttackProcessing(_info.Damage, new Regiment(), _info.DamageType, _info.DamageElement));
        }

        public void Idle()
        {
            OnStateChanged?.Invoke(_unitState = RegimentState.Idle);
        }

        public void Move(ref Field f)
        {
            OnStateChanged?.Invoke(_unitState = RegimentState.Moving);
            _info.MyField = f; // на подумать, мб было бы круче сам процесс передвижения реализовать
        }

        public void MyTurn()
        {
            // запрос на получение массива с полями вокруг отряда
            Field f = _ai.TurnProcessing(_info, _view);
            if (f == _info.MyField)
            {
                Idle();
            }
            else if (f.Regiment == null)
            {
                Move(ref f);
            }
        }

        public Regiment()
        {

        }
    }

    enum RegimentState
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }
}
