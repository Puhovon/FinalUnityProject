using Assets.Scripts.Abstractions;
using Assets.Scripts.PlayerScripts;
using UnityEngine;

namespace Assets.Scripts.Buffs
{
    public class DamageBuff : MonoBehaviour, IBuff
    {
        [SerializeField] private Shooter _shooter;
        [SerializeField] private int _damageMagnifier;
        public void StartBuff() => _shooter.DamageMagnifier += _damageMagnifier;
        

        public void EndBuff() => _shooter.DamageMagnifier -= _damageMagnifier;
    }
}
