
using System;
using Core.Loader;
using Health.Setting;

namespace Health
{
    public class HealthManager
    {
        private const string SETTING_NAME = "HealthSetting";

        private HealthManager(IPrefabLoader prefabLoader)
        {
            _prefabLoader = prefabLoader;
            LoadSettings();

        }
        private HealthManager() { }
        private static Lazy<HealthManager> _instance;
        public static HealthManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public static void Initialize(IPrefabLoader prefabLoader)
        {
            _instance = new(() => new HealthManager(prefabLoader));
        }

        private HealthSetting _model;
        private readonly IPrefabLoader _prefabLoader;

        private void LoadSettings()
        {
            _model = _prefabLoader.Load<HealthSetting>(SETTING_NAME);
        }

        internal bool ValidSpend()
        {
            return _model.Health > 0;
        }

        internal bool ValidSpend(int amount)
        {
            return _model.Health - amount >= 0;
        }
    }
}
