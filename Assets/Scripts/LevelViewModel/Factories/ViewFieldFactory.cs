using UnityEngine;

namespace LevelViewModel
{
    public class ViewFieldFactory // создание префабов полей (view)
    {
        private GameObject _fieldPrefab, _viewGrid;

        public ViewFieldFactory(GameObject viewGrid)
        {
            _fieldPrefab = (GameObject)Resources.Load("Prefabs/FieldPrefab");
            _viewGrid = viewGrid;
        }

        public GameObject CreateFieldPrefab()
        {
            return Object.Instantiate(_fieldPrefab, _viewGrid.transform);
        }
    }
}