using System;
using UnityEngine;

namespace Model
{
    public class FieldEntityInfo
    {
        private Vector2 _position;
        private LevelViewModel.EntitySide _side;
        private EntityType _type;
        private string _name;

        public Vector2 Position => _position;
        public LevelViewModel.EntitySide Side { get => _side; }
        public EntityType Type { get => _type; }
        public string Name { get => _name; }

        public FieldEntityInfo(Vector2 position, string name, LevelViewModel.EntitySide side, EntityType type)
        {
            _position = position;
            _name = name;
            _side = side;
            _type = type;
        }
    }

    public enum EntityType
    {
        Regiment,
        Buff
    }
}