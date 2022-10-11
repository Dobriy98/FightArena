using UnityEngine;
using UnityEngine.AI;

namespace Characters.CharacterMovement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshMovement : MonoBehaviour, ICharacterMovement
    {
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 point)
        {
            _navMeshAgent.SetDestination(point);
        }

        public void SetMovementSpeed(float speed)
        {
            _navMeshAgent.speed = speed;
        }
    }
}