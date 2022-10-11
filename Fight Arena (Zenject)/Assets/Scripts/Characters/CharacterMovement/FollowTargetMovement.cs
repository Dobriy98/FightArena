using UnityEngine;

namespace Characters.CharacterMovement
{
    //This class just for example
    public class FollowTargetMovement : MonoBehaviour, ICharacterMovement
    {
        private float _movementSpeed;

        public void MoveTo(Vector3 point)
        {
            transform.position = Vector3.Lerp(transform.position, point, Time.deltaTime * _movementSpeed);
            transform.LookAt(point);
        }

        public void SetMovementSpeed(float speed)
        {
            _movementSpeed = speed;
        }
    }
}