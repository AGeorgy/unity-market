using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Shop.Setting
{
    [CreateAssetMenu(fileName = "ShopSetting", menuName = "Shop/ShopSetting")]
    public class ShopSetting : ScriptableObject, IBundleSettings
    {
        [SerializeField]
        private List<BundleSetting> _bundles;

        public ReadOnlyCollection<BundleSetting> Bundles => _bundles.AsReadOnly();
    }
}
