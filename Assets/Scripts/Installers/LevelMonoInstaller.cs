using Zenject;

namespace Level
{
    public class LevelMonoInstaller : MonoInstaller
    {
        LevelLoader _loader;
        GameStateMachine _machine;
        FieldController _fContrloller;
        RegimentController _rController;
        public override void InstallBindings()
        {
            _loader = new LevelLoader();
            _fContrloller = new FieldController(_loader);
            _rController = new RegimentController(_loader, _fContrloller);
            _machine = new GameStateMachine(_fContrloller, _rController);
        }
    }
}