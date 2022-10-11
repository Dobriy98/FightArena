using System;
using Characters.TakeDamageBehaviors;
using UnityEngine;

namespace Weapons.Bullets
{
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float timeToDestroyBullet = 2;
        [SerializeField] private float timeToDestroyBulletWhenMakeDamage = 0;
        
        private Weapon _weapon;
        private IBulletShot _bulletShot;

        private void Awake()
        {
            if (!TryGetComponent(out _bulletShot))
            {
                throw new NullReferenceException(
                    $"There is no IBulletShot on {gameObject.name}");
            }
        }

        private void Start()
        {
            _bulletShot.Shot();
        }

        public void SetWeapon(Weapon weapon) => _weapon = weapon;
        protected virtual void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent<IDamageable>(out var damageable))
            {
                DestroyBullet(timeToDestroyBulletWhenMakeDamage);
                
                if(_weapon == null) return;
                damageable.TakeDamage(_weapon.damage);
            }
            
            DestroyBullet(timeToDestroyBullet);
        }

        private void DestroyBullet(float time)
        {
            Destroy(gameObject, time);
        }
    }
}