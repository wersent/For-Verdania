using System;
using UnityEngine;

namespace LevelViewModel
{
    class Field
    {
        private Regiment _regiment;
        private FieldState _fieldState;
        private GameObject _fieldView;
        public event Action<FieldState> FieldStateChanged;

        public Field(GameObject fieldView)
        {
            _fieldState = FieldState.Empty;
            _fieldView = fieldView;
        }

        public GameObject FieldView { get { return _fieldView; } }
        public FieldState FieldState { get { return _fieldState; } }
        public Regiment Regiment{ get { return _regiment;} set { _regiment = value; } }
    }
    
    enum FieldState
    {
        Empty,
        Occupied
    }
}