using UnityEngine;

namespace LevelViewModel
{
    class RegimentFactory
    {
        public GameObject CreateRegimentPrefab(string regimentName, GameObject field)
        {
            return Object.Instantiate((GameObject)Resources.Load("Prefabs/" + regimentName), field.transform);
        }
    }
}