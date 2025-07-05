using System;

namespace Level
{
    class Regiment
    {
        private RegimentSide _side;
        public event Action<ReigmentMove> OnRegimentMove;

        public RegimentSide Side
        {
            get => _side;
            private set => _side = value;
        }

        public Regiment()
        {
        }
    }

    enum RegimentSide
    {
        Player,
        Enemy
    }
    enum ReigmentMove
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }
}