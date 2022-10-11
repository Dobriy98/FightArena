using System;
using System.Collections.Generic;
using Characters.Enemies;
using Factories;
using Zenject;

namespace Spawners
{
    public class EnemySpawner: IInitializable
    {
        private readonly List<Enemy> _spawnedEnemies = new List<Enemy>();
        private readonly IEnemyFactory _enemyFactory;
        private readonly EnemyMarker[] _enemyMarkers;

        public EnemySpawner(IEnemyFactory enemyFactory, EnemyMarker[] enemyMarkers)
        {
            _enemyMarkers = enemyMarkers;
            
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException();
            _enemyFactory.Load();
        }

        public void Initialize()
        {
            CreateEnemies();
        }
        private void CreateEnemies()
        {
            foreach (var enemyMarker in _enemyMarkers)
            {
                var spawnedEnemy = _enemyFactory.Create(enemyMarker.enemyType, enemyMarker.transform.position);
                _spawnedEnemies.Add(spawnedEnemy);
            }
        }

        public List<Enemy> GetSpawnedEnemies() => _spawnedEnemies;
    }
}