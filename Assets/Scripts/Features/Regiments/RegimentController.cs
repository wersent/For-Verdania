using Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Random = UnityEngine.Random;

namespace LevelViewModel
{
    class RegimentController
    {
        private readonly RegimentView.Factory _viewFactory;

        //private RegimentFactory _regimentFactory;
        private int _enemyCount, _playerCount;
        private List<RegimentModel> _regiments;
        public event Action<EntitySide> OnEnd;

        public RegimentController(RegimentView.Factory regViewFactory)
        {
            _viewFactory = regViewFactory;
            //_regimentFactory = new RegimentFactory();
            _regiments = new List<RegimentModel>();
        }

        public RegimentModel CreateRegiment(FieldEntityInfo info, Vector2 coords)
        {
            if (info.Side == EntitySide.Enemy)
            {
                _enemyCount++;
            }
            else
            {
                _playerCount++;
            }

            RegimentModel regimentModel = new(info.Name, info.Side, coords);

            _regiments.Add(regimentModel);

            RegimentViewModel regimentViewModel = new(regimentModel);

            Debug.Log($"Спавн отряда {info.Name} в логической позиции: {coords}");

            _viewFactory.Create(regimentViewModel);

            //GameObject regimentView = _regimentFactory.CreateRegimentPrefab(info.Name, field);
            //Tuple<int, int> node = new Tuple<int, int>(Random.Range(1,5), Random.Range(1,5));
            //RegimentViewModel regiment = new RegimentViewModel(info.Side, regimentView, node, field.transform);

            //regiment.OnRegimentMove += OnRegimentAction;
            //_regiments.Add(regiment);
            return regimentModel;
        }

        private void OnRegimentAction(RegimentAction move, Tuple<int, int> coords)
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