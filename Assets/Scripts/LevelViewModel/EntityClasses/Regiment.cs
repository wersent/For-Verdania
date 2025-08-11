using System;
using Model;
using UnityEngine;

namespace LevelViewModel
{
    class Regiment
    {
        private GameObject _regimentView;
        private EntitySide _side;
        public event Action<RegimentMove> OnRegimentMove;

        public EntitySide Side
        {
            get => _side;
            private set => _side = value;
        }

        public Regiment(EntitySide side, GameObject regimentView)
        {

        }
    }

    enum RegimentSide
    {
        Player,
        Enemy
    }
    enum RegimentMove
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }
    public enum EntitySide
    {
        Player,
        Enemy
    }
}