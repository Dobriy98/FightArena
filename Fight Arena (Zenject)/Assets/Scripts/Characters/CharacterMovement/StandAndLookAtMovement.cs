using UnityEngine;

namespace Characters.CharacterMovement
{
    public class StandAndLookAtMovement : MonoBehaviour, ICharacterMovement
    {
        private float _speed;
        public void MoveTo(Vector3 point)
        {
            transform.LookAt(point);
        }

        public void SetMovementSpeed(float speed)
        {
            _speed = speed;
        }
    }
}