using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using LevelViewModel;


    public class FieldModel : NodeBase
    {
        private RegimentModel _regiment;
        private FieldState _fieldState;
        //private GridController fieldController;
        public event Action<FieldState> FieldStateChanged;

        public FieldModel() 
        {
            _fieldState = FieldState.Empty;
        }

        private static readonly List<Vector2> Dirs = new List<Vector2>() {
            new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1)
        };

        public override void CacheNeighbors(Func<Vector2, NodeBase> getTileAtPosition)
        {
            Neighbors.Clear();

            foreach (var dir in Dirs)
            {
                var neighbor = getTileAtPosition(Coords.Pos + dir);
                if (neighbor != null)
                {
                    Neighbors.Add(neighbor);
                }
            }
        }

        public override void Init(int walkPriority, ICoords coords)
        {
            base.Init(walkPriority, coords);

            //_renderer.transform.rotation = Quaternion.Euler(0, 0, 90 * Random.Range(0, 4));
        }

        public FieldState FieldState { get { return _fieldState; } }
        public RegimentModel Regiment{ get { return _regiment;} set { _regiment = value; } }
    }
    
    public enum FieldState
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
