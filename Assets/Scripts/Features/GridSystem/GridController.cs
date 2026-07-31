using LevelViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

class GridController
{
    private FieldView.Factory _viewFieldFactory;
    private FieldModel[,] _level;
    private GameObject _grid;

    public FieldModel[,] Level
    {
        get => _level;
        private set => _level = value;
    }

    public GridController([Inject(Id = "FieldPrefab")]GameObject grid, FieldView.Factory viewFieldFactory)
    {
        _grid = grid;
        _viewFieldFactory = viewFieldFactory;
    }

    public NodeBase GetTileAtPosition(Vector2 pos)
    {
        return _level[(int)pos.x, (int)pos.y];
    }

    public void CreateField(LevelInfo info, RegimentController rc)
    {
        _level = new FieldModel[info.Size.Item1, info.Size.Item2];
        for (int i = 0; i < info.Size.Item1; i++)
        {
            for (int j = 0; j < info.Size.Item2; j++)
            {
                _level[i, j] = new FieldModel();
                var coords = new SquareCoords { Pos = new Vector2(i, j) };
                _level[i, j].Init(1, coords);

                FieldViewModel fieldViewModel = new(_level[i, j]);

                Debug.Log($"{coords.Pos}");

                _viewFieldFactory.Create(fieldViewModel);
            }
        }

        for (int i = 0; i < info.Size.Item1; i++)
        {
            for (int j = 0; j < info.Size.Item2; j++)
            {
                _level[i, j].CacheNeighbors(pos =>
                {
                    if (pos.x >= 0 && pos.x < info.Size.Item1 && pos.y >= 0 && pos.y < info.Size.Item2)
                        return _level[(int)pos.x, (int)pos.y];
                    return null;
                });
            }
        }
        Debug.Log($"{info.Entities.First().Name}");

        foreach (FieldEntityInfo entity in info.Entities)
        {
            if (entity.Type == EntityType.Regiment)
            {
                FieldModel regField = _level[(int)entity.Position.x, (int)entity.Position.y];

                RegimentModel regiment = rc.CreateRegiment(entity, regField.Coords.Pos);
                _level[(int)entity.Position.x, (int)entity.Position.y].Regiment = regiment;
            }
            else
            {
                throw new System.Exception("Not implemented");
            }
        }

        FieldModel startField = _level[0, 0];
        RegimentModel testRegiment = startField?.Regiment;
        FieldModel targetField = _level[3, 3];

        if (testRegiment != null && targetField != null)
        {
            Debug.Log($"[ТЕСТ] Запуск А* из {startField.Coords.Pos} в {targetField.Coords.Pos}");

            // расстановка препятствий
            FieldModel obstacle = _level[2, 2];
            if (obstacle != null) obstacle.WalkPriority = 4;
            obstacle = _level[1, 1];
            obstacle.WalkPriority = 4;
            obstacle = _level[2, 0];
            obstacle.WalkPriority = 4;

            List<NodeBase> path = Pathfinding.FindPath(startField, targetField);
            path.Reverse();

            if (path != null && path.Count > 0)
            {
                Debug.Log($" длина пути: {path.Count} клеток.");

                for (int i = 0; i < path.Count; i++)
                {
                    Debug.Log($" шаг {i + 1}: клетка {path[i].Coords.Pos}");
                }

                // чисто иллюзия завершения
                startField.Regiment = null;
                testRegiment.Move(targetField.Coords.Pos);
                targetField.Regiment = testRegiment;
            }
            else
            {
                Debug.LogError(" путь не найден");
            }
        }
    }
}
