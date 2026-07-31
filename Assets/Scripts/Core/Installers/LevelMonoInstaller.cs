using Assets.Scripts.Features.GridSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LevelViewModel
{
    public class LevelMonoInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _grid;
        [SerializeField] private GameObject _regPrefab;
        [SerializeField] private GameObject _fieldPrefab;
        [SerializeField] private GameObject FieldsContainer;
        [SerializeField] private Transform RegimentsContainer;
        [SerializeField] private GridLayoutGroup _fieldGridLG;
        private GridController _fContrloller;
        private RegimentController _rController;
        private LevelLoader _loader;
        private GameStateMachine _machine;
        
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("FieldPrefab").FromInstance(_grid);
            Container.Bind<RegimentViewModel>().AsSingle();

            Container.Bind<GridLayoutGroup>().FromInstance(_fieldGridLG).AsSingle();
            Container.Bind<IUiCoordinateConverter>().To<CoordinateConverter>().AsCached();

            Container.Bind<GridController>().AsSingle().NonLazy();
            Container.Bind<RegimentController>().AsSingle().NonLazy();

            Container.Bind<LevelLoader>().AsSingle().WithArguments("testpath").NonLazy();

            Container.Bind<GameStateMachine>().AsSingle().NonLazy();

            Container.BindFactory<FieldViewModel, FieldView, FieldView.Factory>()
                .FromComponentInNewPrefab(_fieldPrefab)
                .UnderTransform(FieldsContainer.transform)
                .AsSingle();

            Container.BindFactory<RegimentViewModel, RegimentView, RegimentView.Factory>()
                .FromSubContainerResolve()
                .ByMethod((subContainer, viewModel) =>
                {
                    subContainer.Bind<RegimentViewModel>()
                        .FromInstance(viewModel)
                        .AsSingle();

                    subContainer.Bind<RegimentView>()
                        .FromComponentInNewPrefab(_regPrefab)
                        .UnderTransform(RegimentsContainer)
                        .AsSingle();
                });

            //Container.BindFactory<FieldViewModel, FieldView, FieldView.Factory>()
        }
    }
}