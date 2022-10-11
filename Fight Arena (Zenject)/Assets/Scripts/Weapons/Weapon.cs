using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public float cooldown = 3;
        public float damage = 1;
        public abstract void Attack();
    }
}