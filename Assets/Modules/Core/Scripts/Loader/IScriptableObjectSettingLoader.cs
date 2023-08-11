
namespace Core.Loader
{
    public interface IScriptableObjectSettingLoader
    {
        T Load<T>(string path) where T : UnityEngine.Object;
    }
}
