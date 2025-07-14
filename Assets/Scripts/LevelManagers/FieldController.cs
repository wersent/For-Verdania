namespace Level
{
    class FieldController
    {
        private Field[,] _level;
        public FieldController(LevelLoader loader)
        {
            UnityEngine.Debug.Log("FieldController");
            _level = new Field[loader.LevelSize.Item1, loader.LevelSize.Item2];
        }

        public Field[,] Level
        {
            get => _level;
            private set => _level = value;
        }
    }
}