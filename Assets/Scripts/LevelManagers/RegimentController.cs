using System;
using System.Collections.Generic;
using Zenject;

namespace Level
{
    class RegimentController
    {
        private int _enemyCount, _playerCount;
        private List<Regiment> _regiments;
        public event Action<RegimentSide> OnEnd;

        public RegimentController(LevelLoader loader, FieldController controller)
        {
            UnityEngine.Debug.Log("RegimentController");
            foreach (Regiment r in loader.Regiments)
            {
                _regiments.Add(r);
                if (r.Side == RegimentSide.Player)
                {
                    _playerCount++;
                }
                else
                {
                    _enemyCount++;
                }
                r.OnRegimentMove += OnRegimentMove;
            }
        }

        private void OnRegimentMove(RegimentMove move)
        {
            if (_playerCount == 0)
            {
                OnEnd?.Invoke(RegimentSide.Enemy);
            }
            else if (_enemyCount == 0)
            {
                OnEnd?.Invoke(RegimentSide.Player);
            }
        }
    }
}