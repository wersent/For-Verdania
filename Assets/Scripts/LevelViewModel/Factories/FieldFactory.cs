using UnityEngine;

namespace LevelViewModel
{
    public class FieldFactory
    {
        private GameObject _fieldPrefab, _grid;

        public FieldFactory(GameObject grid)
        {
            _fieldPrefab = (GameObject)Resources.Load("Prefabs/FieldPrefab");
            _grid = grid;
        }

        public GameObject CreateFieldPrefab()
        {
            return Object.Instantiate(_fieldPrefab, _grid.transform);
        }
    }
}