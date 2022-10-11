using System;
using UnityEngine;

namespace Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletPhysicalShot : MonoBehaviour, IBulletShot
    {
        [SerializeField] private float forcePower = 2000;
        
        private Rigidbody _bulletRb;

        private void Awake()
        {
            if (!TryGetComponent(out _bulletRb))
            {
                throw new NullReferenceException(
                    $"There is no RigidBody on bullet {gameObject.name}");
            }
        }

        public void Shot()
        {
            if(_bulletRb == null) return;
            _bulletRb.AddForce(transform.forward * forcePower);
        }
    }
}