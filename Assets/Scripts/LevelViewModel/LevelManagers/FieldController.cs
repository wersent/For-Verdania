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
            foreach (FieldEntityInfo entity in info.Entities)
            {
                GameObject fieldView = _fieldFactory.CreateFieldPrefab();
                if (entity.Type == EntityType.Regiment)
                {
                    Regiment regiment = rc.CreateRegiment(entity, fieldView);
                    _level[entity.Position.Item1, entity.Position.Item2] = new Field(regiment);
                }
                else
                {
                    throw new System.Exception("Not implemented");
                }
            }
        }
    }
}