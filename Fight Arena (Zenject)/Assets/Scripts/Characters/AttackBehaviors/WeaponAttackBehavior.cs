using System;
using UnityEngine;
using Weapons;

namespace Characters.AttackBehaviors
{
    public class WeaponAttackBehavior : MonoBehaviour, IAttackBehavior
    {
        [SerializeField] private Weapon weapon;
        
        private float _timer;

        private bool CanAttack => _timer <= 0;

        private void Start()
        {
            if (weapon == null){
                Debug.LogError($"There is no weapon in attack behavior on {gameObject.name}");
                weapon = gameObject.AddComponent<NullWeapon>();
            }

            _timer = 0;
        }

        public void Update()
        {
            if (!CanAttack)
            {
                _timer -= Time.deltaTime;
            }
        }

        private void ResetTimer()
        {
            _timer = weapon.cooldown;
        }

        public virtual void Attack()
        {
            if (CanAttack)
            {
                weapon.Attack();
                ResetTimer();
            }
        }
    }
}