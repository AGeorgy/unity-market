using UnityEngine;

namespace Gold.Setting
{
    [CreateAssetMenu(fileName = "GoldSetting", menuName = "Game/GoldSetting")]
    public class GoldSetting : ScriptableObject
    {
        [SerializeField]
        private int _gold;

        public int Gold => _gold;
    }
}
