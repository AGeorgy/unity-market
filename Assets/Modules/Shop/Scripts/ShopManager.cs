
using System;
using Core.Loader;
using Shop.Setting;

namespace Shop
{
    public class ShopManager : IShopShower
    {
        private const string SHOP_SCENE_NAME = "Shop";

        private ShopManager()
        {
        }
        private static readonly Lazy<ShopManager> lazy = new(() => new ShopManager());
        public static ShopManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private ShopSetting _shopSetting;
        public ShopSetting ShopSetting => _shopSetting;

        public void LoadSettings(IScriptableObjectSettingLoader settingLoader)
        {
            _shopSetting = settingLoader.Load<ShopSetting>("ShopSetting");
        }

        public void SowShop(ISceneLoader sceneLoader)
        {
            sceneLoader.Load(SHOP_SCENE_NAME);
        }
    }




}
