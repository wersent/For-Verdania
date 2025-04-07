using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private ArcherScript _archer;
    //[SerializeField] private RookieScript _rookie;
    [SerializeField] private List<Unit> units = new();

    private void Awake()
    {
        units.Clear();
        foreach (var unitType in gameObject.GetComponentsInChildren<Unit>())
        {
            units.Add(unitType);
        }
        foreach (var unit in units)
        {
            Debug.Log(unit);
        }
    }
}
