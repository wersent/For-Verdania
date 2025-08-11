using System;
using Model;
using UnityEngine;
using System.Collections.Generic;

namespace LevelViewModel
{
    class RegimentController
    {
        private RegimentFactory _regimentFactory;
        private int _enemyCount, _playerCount;
        private List<Regiment> _regiments;
        public event Action<EntitySide> OnEnd;

        public RegimentController()
        {
            _regimentFactory = new RegimentFactory();
            _regiments = new List<Regiment>();
        }

        public Regiment CreateRegiment(FieldEntityInfo info, GameObject field)
        {
            if (info.Side == EntitySide.Enemy)
            {
                _enemyCount++;
            }
            else
            {
                _playerCount++;
            }
            GameObject regimentView = _regimentFactory.CreateRegimentPrefab(info.Name, field);
            Regiment regiment = new Regiment(info.Side, regimentView);
            regiment.OnRegimentMove += OnRegimentMove;
            _regiments.Add(regiment);
            return regiment;
        }
        private void OnRegimentMove(RegimentMove move)
        {
            if (_playerCount == 0)
            {
                OnEnd?.Invoke(EntitySide.Enemy);
            }
            else if (_enemyCount == 0)
            {
                OnEnd?.Invoke(EntitySide.Player);
            }
        }
    }
}