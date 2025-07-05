using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class FieldManager : MonoBehaviour
{
    [SerializeField] private int _weight, _height;
    [SerializeField] private float spacing = 2f;

    [SerializeField] private Placement _placementPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        Vector3 prefabScale = _placementPrefab.transform.localScale;

        for (int x = 0; x < _weight; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                // ��������� scale ��� ������� �������
                float posX = (x - _weight / 2f + 0.5f) * (spacing * prefabScale.x + 0.015f);
                float posY = (y - _height / 1.68f + 0.5f) * (spacing * prefabScale.y + 0.1f);

                Vector3 position = new(posX, posY, 0);

                var spawnedPlacement = Instantiate(_placementPrefab, position, Quaternion.identity);
                spawnedPlacement._allyMenuInfo = GetComponent<AllyMenuInfo>();
                spawnedPlacement.name = $"Placement {x} {y}";

                // �����: ������� scale �� ����������� �������, ���� �� ��� ���� � �������
                spawnedPlacement.transform.localScale = prefabScale;
            }
        }
    }
}
*/