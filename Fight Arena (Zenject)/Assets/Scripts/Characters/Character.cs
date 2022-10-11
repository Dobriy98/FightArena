using Characters.CharacterMovement;
using Characters.AttackBehaviors;
using UnityEngine;

namespace Characters
{
    public class Character : MonoBehaviour
    {
        public float initialMovementSpeed = 1;
        public float initialHealth = 100;
        
        [HideInInspector]
        public float health;

        protected ICharacterMovement _characterMovement;
        protected IAttackBehavior _attackBehavior;

        protected virtual void Start()
        {
            CheckCharacterMovementComponent();
            CheckAttackBehaviorComponent();

            health = initialHealth;
        }

        public void SetCharacterMovement(ICharacterMovement characterMovement)
            => _characterMovement = characterMovement;

        private void CheckCharacterMovementComponent()
        {
            if (TryGetComponent(out _characterMovement))
            {
                _characterMovement.SetMovementSpeed(initialMovementSpeed);
            }
            else
            {
                Debug.LogWarning($"There is no ICharacterMovement on {gameObject.name}");
                _characterMovement = new NullCharacterMovement();
            }
        }

        private void CheckAttackBehaviorComponent()
        {
            if (!TryGetComponent(out _attackBehavior))
            {
                Debug.LogWarning($"There is no IAttackBehavior on {gameObject.name}");
                _attackBehavior = new NullAttackBehavior();
            }
        }

    }
}