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
            _side = side;
            _regimentView = regimentView;
        }

        private Tuple<int, int> Pathfinder(Tuple<int, int> destination)
        {
            Tuple<int, int> field = Tuple.Create(0, 0);
            return field;
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