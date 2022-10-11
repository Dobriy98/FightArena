using UnityEngine;

namespace Characters.Enemies
{
    public class EnemyMarker : MonoBehaviour
    {
        public EnemyType enemyType;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.3f);
            Gizmos.color = Color.white;
        }
    }
}