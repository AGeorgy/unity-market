using System;
using Core.Loader;
using Rating.Setting;

namespace Rating
{
    public class RatingManager
    {
        private const string SETTING_NAME = "RatingSetting";

        private RatingManager(IPrefabLoader prefabLoader)
        {
            _prefabLoader = prefabLoader;
            LoadSettings();

        }
        private RatingManager() { }
        private static Lazy<RatingManager> _instance;
        public static RatingManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public static void Initialize(IPrefabLoader prefabLoader)
        {
            _instance = new(() => new RatingManager(prefabLoader));
        }

        private RatingSetting _model;
        private readonly IPrefabLoader _prefabLoader;

        private void LoadSettings()
        {
            _model = _prefabLoader.Load<RatingSetting>(SETTING_NAME);
        }

        internal bool ValidSpend(int amount)
        {
            return _model.Rating - amount >= 0;
        }
    }
}
