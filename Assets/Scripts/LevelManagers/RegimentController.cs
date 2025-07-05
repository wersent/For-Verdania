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

        private void OnRegimentMove(ReigmentMove move)
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