using UnityEngine;
using Weapons.Bullets;

namespace Weapons
{
    public class RangeWeapon : Weapon
    {
        [SerializeField] protected Bullet bulletPrefab;
        [SerializeField] protected Transform spawnBulletPoint;
        public override void Attack()
        {
            var bullet = Instantiate(bulletPrefab, spawnBulletPoint.position, spawnBulletPoint.rotation);
            bullet.SetWeapon(this);
        }
    }
}