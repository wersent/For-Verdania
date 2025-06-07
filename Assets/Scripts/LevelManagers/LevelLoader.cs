using System;

namespace Level
{
    class LevelLoader
    {
        private Tuple<int, int> _levelSize;

        public Tuple<int, int> LevelSize
        {
            get => _levelSize;
            private set => _levelSize = value;
        }

        public LevelLoader()
        {
            _levelSize = new Tuple<int, int>(5, 5);
        }
    }
}