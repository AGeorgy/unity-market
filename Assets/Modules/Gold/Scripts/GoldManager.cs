using System;
using Core;
using Core.Loader;
using Gold.Setting;

namespace Gold
{
    public class GoldManager
    {
        private const string SETTING_NAME = "GoldSetting";

        private GoldManager(IPrefabLoader prefabLoader)
        {
            _prefabLoader = prefabLoader;
            LoadSettings();

        }
        private GoldManager() { }
        private static Lazy<GoldManager> _instance;
        public static GoldManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public static void Initialize(IPrefabLoader prefabLoader)
        {
            _instance = new(() => new GoldManager(prefabLoader));
        }

        private GoldModel _model;
        private readonly IPrefabLoader _prefabLoader;

        private void LoadSettings()
        {
            var setting = _prefabLoader.Load<GoldSetting>(SETTING_NAME);
            _model = new GoldModel(setting);
        }

        public bool ValidSpend(int amount)
        {
            return _model.Gold - amount >= 0;
        }
    }
}
