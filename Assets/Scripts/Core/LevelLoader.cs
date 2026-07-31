using System;
using Model;
using System.Collections.Generic;

namespace LevelViewModel
{
    class LevelLoader
    {
        private List<RegimentViewModel> _regiments = new List<RegimentViewModel>();
        private Tuple<int, int> _levelSize;

        public List<RegimentViewModel> Regiments
        {
            get => _regiments;
            private set => _regiments = value;
        }
        public Tuple<int, int> LevelSize
        {
            get => _levelSize;
            private set => _levelSize = value;
        }

        public LevelLoader(string path, GridController fc, RegimentController rc)
        {
            LevelInfo level = JSONParser.LevelParser(path);
            fc.CreateField(level, rc);
        }
    }
}