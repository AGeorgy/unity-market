
namespace Core.Loader
{
    public class LoaderFabric
    {
        public IScriptableObjectSettingLoader GetScriptableObjectLoader()
        {
            return new ScriptableObjectSettingLoader();
        }

        public ISceneLoader GetSceneLoader()
        {
            return new SceneLoader();
        }
    }
}
