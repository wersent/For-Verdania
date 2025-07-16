using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    class Field
    {
        private Regiment _regiment;
        private FieldState _fieldState;
        public event Action<FieldState> FieldStateChanged;

        //public Field(FieldScriptable fieldInfo)
        //{
        //    _fieldState = FieldState.Empty;
        //    _regiment = fieldInfo.Regiment;
        //}

        public Regiment Regiment
        {
            get { return _regiment; }
        }
    }

    enum FieldState
    {
        Empty,
        Occupied
    }
}
