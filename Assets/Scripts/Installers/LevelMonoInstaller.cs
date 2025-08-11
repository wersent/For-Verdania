using Zenject;
using UnityEngine;

namespace LevelViewModel
{
    public class LevelMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _grid;
        private FieldController _fContrloller;
        private RegimentController _rController;
        private LevelLoader _loader;
        private GameStateMachine _machine;
        
        public override void InstallBindings()
        {
            FieldController _fContrloller = new FieldController(_grid);
            RegimentController _rController = new RegimentController();
            LevelLoader _loader = new LevelLoader("testpath", _fContrloller, _rController);
            GameStateMachine _machine = new GameStateMachine(_fContrloller, _rController);
        }
    }
}