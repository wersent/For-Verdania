using System;
using UnityEngine;

namespace Model
{
    public static class JSONParser
    {
        public static LevelInfo LevelParser(string path)
        {
            return new LevelInfo(new Tuple<int, int>(5, 5),
            new FieldEntityInfo[1]
            {
                new FieldEntityInfo(new Vector2(0, 0),
                "goon",
                LevelViewModel.EntitySide.Enemy,
                EntityType.Regiment),

                //new FieldEntityInfo(new Tuple<int, int>(1, 2),
                //"goon",
                //LevelViewModel.EntitySide.Enemy,
                //EntityType.Regiment),
                
                //new FieldEntityInfo(new Tuple<int, int>(4, 4),
                //"goon",
                //LevelViewModel.EntitySide.Enemy,
                //EntityType.Regiment)
            });
        }
    }
}