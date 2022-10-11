using System;
using Characters.MainCharacterModel;
using Zenject;

namespace Characters.Enemies
{
    public class Enemy : Character
    {
        private MainCharacter _mainCharacter;

        [Inject]
        public void Construct(MainCharacter mainCharacter)
        {
            _mainCharacter = mainCharacter 
                ? mainCharacter 
                : throw new ArgumentNullException();
        }

        private void Update()
        {
            Move();
            Attack();
        }

        protected virtual void Move()
        {
            if (_mainCharacter == null) return;
            _characterMovement.MoveTo(_mainCharacter.transform.position);
        }

        protected virtual void Attack()
        {
            _attackBehavior.Attack();
        }
    }
}
