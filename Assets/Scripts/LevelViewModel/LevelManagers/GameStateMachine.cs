using UnityEngine;

namespace LevelViewModel
{
    class GameStateMachine
    {
        public GameStateMachine(FieldController fc, RegimentController rc)
        {
            rc.OnEnd += OnEnd;
        }

        private void OnEnd(EntitySide side)
        {

        }
        private void OnFieldStateChanged(FieldState state)
        {

        }
    }

    enum GameState
    {
        Planning,
        Running,
        Paused,
        GameOver
    }
}