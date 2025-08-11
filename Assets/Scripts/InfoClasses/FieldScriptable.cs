using UnityEngine;
using LevelViewModel;

class FieldScriptable : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    private Regiment _Regiment;

    public Sprite Sprite { get { return _sprite; } }
    public Regiment Regiment { get { return _Regiment; } }
}
