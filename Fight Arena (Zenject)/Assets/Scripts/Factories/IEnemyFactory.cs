using Characters.Enemies;
using UnityEngine;

namespace Factories
{
    public interface IEnemyFactory
    {
        void Load();
        Enemy Create(EnemyType enemyType, Vector3 atPoint);
    }
}