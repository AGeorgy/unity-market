
namespace Core.Loader
{
    public interface IPrefabLoader
    {
        T Load<T>(string path) where T : UnityEngine.Object;
    }
}
