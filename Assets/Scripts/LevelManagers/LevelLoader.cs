using System;
using System.Collections.Generic;

namespace Level
{
    class LevelLoader
    {
        private List<Regiment> _regiemts = new List<Regiment>();
        private Tuple<int, int> _levelSize;

        public List<Regiment> Regiments
        {
            get => _regiemts;
            private set => _regiemts = value;
        }
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