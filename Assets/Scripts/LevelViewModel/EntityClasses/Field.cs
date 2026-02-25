using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace LevelViewModel
{
    class Field : NodeBase
    {
        private Regiment _regiment;
        private FieldState _fieldState;
        private FieldController fieldController;
        private GameObject _fieldView;
        public event Action<FieldState> FieldStateChanged;

        public Field(GameObject fieldView)
        {
            _fieldState = FieldState.Empty;
            _fieldView = fieldView;
        }

        private static readonly List<Vector2> Dirs = new List<Vector2>() {
            new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1)
        };

        public override void CacheNeighbors()
        {
            Neighbors = new List<NodeBase>();

            foreach (var tile in Dirs.Select(dir => fieldController.GetTileAtPosition(Coords.Pos + dir)).Where(tile => tile != null))
            {
                Neighbors.Add(tile);
            }
        }

        public override void Init(int walkPriority, ICoords coords)
        {
            base.Init(walkPriority, coords);

            //_renderer.transform.rotation = Quaternion.Euler(0, 0, 90 * Random.Range(0, 4));
        }

        public GameObject FieldView { get { return _fieldView; } }
        public FieldState FieldState { get { return _fieldState; } }
        public Regiment Regiment{ get { return _regiment;} set { _regiment = value; } }
    }
    
    enum FieldState
    {
        Empty,
        Occupied
    }

    public struct SquareCoords : ICoords
    {

        public float GetDistance(ICoords other)
        {
            var dist = new Vector2Int(Mathf.Abs((int)Pos.x - (int)other.Pos.x), Mathf.Abs((int)Pos.y - (int)other.Pos.y));

            var lowest = Mathf.Min(dist.x, dist.y);
            var highest = Mathf.Max(dist.x, dist.y);

            var horizontalMovesRequired = highest - lowest;

            return lowest * 14 + horizontalMovesRequired * 10;
        }

        public Vector2 Pos { get; set; }
    }
}