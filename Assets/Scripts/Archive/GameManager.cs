using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScrollViewHandler _scrollViewHandler;
    [SerializeField] private AllyMenuInfo _allyMenuInfo;
    public List<Regiment> units = new();

    private void Awake()
    {
        units.Clear();
        foreach (var unitType in gameObject.GetComponentsInChildren<Regiment>())
        {           
            units.Add(unitType);
        }

        var unitsSrollView = Instantiate(_scrollViewHandler, _allyMenuInfo.transform);
        ScrollViewHandler scrollViewHandler = unitsSrollView.GetComponent<ScrollViewHandler>();
        scrollViewHandler.Initialize(this.gameObject);
    }
}
