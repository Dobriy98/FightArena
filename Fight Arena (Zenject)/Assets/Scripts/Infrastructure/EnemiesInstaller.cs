using Characters;
using Characters.Enemies;
using Factories;
using Spawners;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class EnemiesInstaller : MonoInstaller
    {
        [SerializeField] private EnemyMarker[] enemyMarkers;
        public override void InstallBindings()
        {
            BindEnemyFactory();
            BindEnemyMarkers();
            BindEnemySpawnerInterfaces();
        }
        private void BindEnemyFactory()
        {
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }

        private void BindEnemyMarkers()
        {
            Container
                .Bind<EnemyMarker[]>()
                .FromInstance(enemyMarkers);
        }

        private void BindEnemySpawnerInterfaces()
        {
            Container
                .BindInterfacesAndSelfTo<EnemySpawner>()
                .AsSingle();
        }
    }
}