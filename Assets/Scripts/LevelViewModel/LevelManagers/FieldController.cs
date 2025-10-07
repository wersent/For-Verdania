using Model;
using UnityEngine;

namespace LevelViewModel
{
    class FieldController
    {
        private FieldFactory _fieldFactory;
        private Field[,] _level;

        public Field[,] Level
        {
            get => _level;
            private set => _level = value;
        }

        public FieldController(GameObject grid)
        {
            _fieldFactory = new FieldFactory(grid);
        }

        public void CreateField(LevelInfo info, RegimentController rc)
        {
            _level = new Field[info.Size.Item1, info.Size.Item2];
            for (int i = 0; i < info.Size.Item1; i++)
            {
                for (int j = 0; j < info.Size.Item2; j++)
                {
                    _level[i, j] = new Field(_fieldFactory.CreateFieldPrefab());
                }
            }
            foreach (FieldEntityInfo entity in info.Entities)
            {
                if (entity.Type == EntityType.Regiment)
                {
                    Regiment regiment = rc.CreateRegiment(entity, _level[entity.Position.Item1, entity.Position.Item2].FieldView);
                    _level[entity.Position.Item1, entity.Position.Item2].Regiment = regiment;
                }
                else
                {
                    throw new System.Exception("Not implemented");
                }
            }
        }
    }
}