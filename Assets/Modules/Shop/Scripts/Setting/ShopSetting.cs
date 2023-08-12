using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Shop.Setting
{
    [CreateAssetMenu(fileName = "ShopSetting", menuName = "Game/ShopSetting")]
    public class ShopSetting : ScriptableObject, IBundleSettings
    {
        [SerializeReference, SelectImplementation(typeof(IBundleSetting))]
        private List<IBundleSetting> _bundles;

        public List<IBundleSetting> Bundles => _bundles;
    }
}
