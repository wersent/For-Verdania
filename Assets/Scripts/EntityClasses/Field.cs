using System;

namespace Level
{
    class Field
    {
        private Regiment _regiment;
        private FieldState _fieldState;
        public event Action<FieldState> FieldStateChanged;

        public Field(FieldScriptable fieldInfo)
        {
            _fieldState = FieldState.Empty;
            _regiment = fieldInfo.Regiment;
        }
    }

    enum FieldState
    {
        Empty,
        Occupied
    }
}