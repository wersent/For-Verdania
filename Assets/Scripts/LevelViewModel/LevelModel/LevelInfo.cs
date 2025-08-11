using System;

namespace Model
{
    public class LevelInfo
    {
        private Tuple<int, int> _size;
        private FieldEntityInfo[] _entities;

        public Tuple<int, int> Size { get => _size; }
        public FieldEntityInfo[] Entities { get => _entities; }

        public LevelInfo(Tuple<int, int> size, FieldEntityInfo[] entities)
        {
            _size = size;
            _entities = entities;
        } 
    }
}