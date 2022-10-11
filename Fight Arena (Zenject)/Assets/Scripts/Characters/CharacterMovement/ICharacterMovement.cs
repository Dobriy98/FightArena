using UnityEngine;

namespace Characters.CharacterMovement
{
    public interface ICharacterMovement
    {
        void MoveTo(Vector3 point);
        void SetMovementSpeed(float speed);
    }
}