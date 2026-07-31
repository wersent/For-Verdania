using System;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace LevelViewModel
{
    public class RegimentViewModel
    {
        private Vector2 _destination;
        private RegimentModel _regimentM;
        private GridController fieldController;
        private List<NodeBase> _movePath = new();
        private Vector2 _currentPosition;
        public event Action<RegimentAction, Vector2> OnRegimentMove;

        public Vector2 CurrentPosition
        {
            get => _currentPosition;
            private set => _currentPosition = value;
        }

        public RegimentViewModel(RegimentModel regiment) //, Tuple<int, int> desinationNode, Transform currentPosition)
        {
            _regimentM = regiment;
            _currentPosition = _regimentM.RegPos;
            _regimentM.OnRegimentMove += Move;
            //_destination = desinationNode;
            //_currentPosition = new Tuple<int, int>(((int)currentPosition.position.x), ((int)currentPosition.position.y));
        }

        public void Move(RegimentAction regAction, Vector2 newPos)
        {
            _currentPosition = newPos;
            Debug.Log($"{_currentPosition}");
            OnRegimentMove?.Invoke(regAction, _currentPosition);
        }
    }

    public enum RegimentAction
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