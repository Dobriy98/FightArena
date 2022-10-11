using Characters.Enemies;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private Enemy _cubeEnemyPrefab;
        private Enemy _sphereEnemyPrefab;

        private readonly DiContainer _diContainer;

        private const string EnemyCubePath = "Enemies/EnemyCube";
        private const string EnemySpherePath = "Enemies/EnemySphere";

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Load()
        {
            _cubeEnemyPrefab = Resources.Load<Enemy>(EnemyCubePath);
            _sphereEnemyPrefab = Resources.Load<Enemy>(EnemySpherePath);
        }

        public Enemy Create(EnemyType enemyType, Vector3 atPoint)
        {
            switch (enemyType)
            {
                case EnemyType.Cube:
                    return _diContainer.InstantiatePrefabForComponent<Enemy>(
                        _cubeEnemyPrefab, atPoint, Quaternion.identity, null);
                case EnemyType.Sphere:
                    return _diContainer.InstantiatePrefabForComponent<Enemy>(
                        _sphereEnemyPrefab, atPoint, Quaternion.identity, null);
                default:
                    return null;
            }
        }
    }
}