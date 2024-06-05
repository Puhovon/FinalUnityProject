using UnityEngine;

namespace Assets.Scripts.Global
{
    [CreateAssetMenu(menuName = "Configs/Global", fileName = "Config")]
    public class GlobalConfig : ScriptableObject
    {
        [SerializeField] private int _health;

        public int Health => _health;
    }
}