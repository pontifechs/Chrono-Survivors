using System;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName="Weapon")]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private float size;
        [SerializeField] private float damage;
        [SerializeField] private float speed;
        [SerializeField] private float cooldown;


    }
}