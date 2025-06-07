using System;

namespace Level
{
    class Regiment
    {
        private ReigmentState _unitState;
        public event Action<ReigmentState> OnStateChanged;
        public Regiment()
        {
        }
    }

    enum ReigmentState
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }
}