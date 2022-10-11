using UnityEngine;

namespace Characters.TakeDamageBehaviors
{
    [RequireComponent(typeof(Character))]
    public class CharacterTakeDamageBehavior : MonoBehaviour, IDamageable
    {
        private Character _character;
        private bool IsDead => _character.health <= 0;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public virtual void TakeDamage(float damage)
        {
            _character.health -= damage;
            if(IsDead) Death();
        }
        
        protected virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}