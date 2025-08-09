using System;
using UnityEngine;

namespace LevelViewModel
{
    class Field
    {
        private Regiment _regiment;
        private FieldState _fieldState;
        public event Action<FieldState> FieldStateChanged;

        public Field(Regiment regiment)
        {
            _fieldState = FieldState.Empty;
            _regiment = regiment;
        }
    }

    enum FieldState
    {
        Empty,
        Occupied
    }
}