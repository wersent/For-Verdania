using System;
using Model;
using System.Collections.Generic;

namespace LevelViewModel
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

        public LevelLoader(string path, FieldController fc, RegimentController rc)
        {
            LevelInfo level = JSONParser.LevelParser(path);
            fc.CreateField(level, rc);
        }
    }
}