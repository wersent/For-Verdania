namespace Level
{
    class GameStateMachine
    {
        private void OnFieldStateChanged(FieldState state)
        {

        }
        public GameStateMachine(FieldController fc)
        {
            foreach (Field f in fc.Level)
            {
                f.FieldStateChanged += OnFieldStateChanged;
            }
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