using System.ComponentModel;
using Characters;
using Inputs;
using UI;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private Canvas gameplayCanvas;
        [SerializeField] private InputPanel mouseService;

        private Canvas _gameplayCanvas;
        public override void InstallBindings()
        {
            CreateGameplayCanvas();
            BindMouseService();
        }

        private void BindMouseService()
        {
            IMouseService mouseServiceInstance = Container
                .InstantiatePrefabForComponent<IMouseService>(mouseService, _gameplayCanvas.transform);

            Container
                .Bind<IMouseService>()
                .FromInstance(mouseServiceInstance)
                .AsSingle();
        }

        private void CreateGameplayCanvas()
        {
            _gameplayCanvas = Container
                .InstantiatePrefabForComponent<Canvas>(gameplayCanvas);
        }
    }
}
