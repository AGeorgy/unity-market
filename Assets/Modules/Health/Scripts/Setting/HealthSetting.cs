using UnityEngine;

namespace Health.Setting
{
    [CreateAssetMenu(fileName = "HealthSetting", menuName = "Game/HealthSetting")]
    public class HealthSetting : ScriptableObject
    {
        [SerializeField]
        private int _health;

        public int Health => _health;
    }
}
