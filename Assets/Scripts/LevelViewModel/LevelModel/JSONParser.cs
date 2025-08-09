using System;

namespace Model
{
    public static class JSONParser
    {
        public static LevelInfo LevelParser(string path)
        {
            return new LevelInfo(new Tuple<int, int>(5, 5),
            new FieldEntityInfo[3]
            {
                new FieldEntityInfo(new Tuple<int, int>(2, 2),
                "goon",
                LevelViewModel.EntitySide.Enemy,
                EntityType.Regiment),

                new FieldEntityInfo(new Tuple<int, int>(3, 3),
                "goon",
                LevelViewModel.EntitySide.Enemy,
                EntityType.Regiment),
                
                new FieldEntityInfo(new Tuple<int, int>(4, 4),
                "goon",
                LevelViewModel.EntitySide.Enemy,
                EntityType.Regiment)
            });
        }
    }
}