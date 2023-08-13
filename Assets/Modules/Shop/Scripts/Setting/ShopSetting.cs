using System.Collections.Generic;
using UnityEngine;

namespace Shop.Setting
{
    [CreateAssetMenu(fileName = "ShopSetting", menuName = "Game/ShopSetting")]
    public class ShopSetting : ScriptableObject
    {
        [SerializeField]
        private List<BundleSetting> _bundles;

        public List<BundleSetting> Bundles => _bundles;
    }
}
