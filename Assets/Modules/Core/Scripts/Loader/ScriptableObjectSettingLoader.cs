namespace Core.Loader
{
    public class ScriptableObjectSettingLoader : IScriptableObjectSettingLoader
    {
        public T Load<T>(string path) where T : UnityEngine.Object
        {
            return UnityEngine.Resources.Load<T>(path);
        }
    }
}